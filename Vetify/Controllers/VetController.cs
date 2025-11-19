using BL.Abstract;
using BL.Concrete;
using DAL;
using EL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Vetify.Models.ViewModel;

namespace Vetify.Controllers
{
    [Authorize(Roles = "Admin")]
    public class VetController : Controller
    {
        private readonly IHayvanService _hayvanService;
        private readonly IOdemeService _odemeService;
        private readonly IRandevuService _randevuService;
        private readonly ISaglikKaydiService _saglikKaydiService;
        private readonly ITedaviService _tedaviService;
        private readonly UserManager<Kullanici> _userManager;


        public VetController(IHayvanService hayvanServicei,
                            IOdemeService odemeService,
                            IRandevuService randevuService,
                            ISaglikKaydiService saglikKaydiService,
                            ITedaviService tedaviService,
                            UserManager<Kullanici> userManager)
        {
            _hayvanService = hayvanServicei;
            _odemeService = odemeService;
            _randevuService = randevuService;
            _saglikKaydiService = saglikKaydiService;
            _tedaviService = tedaviService;
            _userManager = userManager;
        }

        private int GetUserId()
        {
            var userIdString = _userManager.GetUserId(User);
            int.TryParse(userIdString, out int userId);
            return userId;
        }

        public async Task<IActionResult> Index()
        {
            VetDashboardViewModel viewModel = new VetDashboardViewModel();
            viewModel.ToplamHayvan = await _hayvanService.Query().CountAsync();


            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);

            viewModel.BugunkuRandevu = await _randevuService.Query()
                .Where(x => x.RandevuZamani >= today && x.RandevuZamani < tomorrow)
                .CountAsync();


            viewModel.BugunkuRandevuTamamlandi = await _randevuService.Query().Where(x => x.RandevuZamani.Date == DateTime.Today && x.Tedaviler.Any()).CountAsync();
            var next7 = today.AddDays(7);
            viewModel.BekleyenRandevu = await _randevuService.Query()
                .Where(x => x.RandevuZamani >= today &&
                            x.RandevuZamani < next7 &&
                            !x.Tedaviler.Any())
                .CountAsync(); viewModel.AylıkGelir = await _tedaviService.Query().Select(x => x.Ucret).SumAsync();

            var oneMonthAgo = DateTime.Today.AddMonths(-1);

            viewModel.AylıkGelir = await _tedaviService.Query()
                .Where(x => x.TedaviTarihi >= oneMonthAgo)
                .SumAsync(x => x.Ucret);

            viewModel.BugunkuRandevular = await _randevuService.Query().Include(x => x.Musteri).Include(x => x.Hayvan).Where(x => x.RandevuZamani.Date == DateTime.Today).ToListAsync();
            return View(viewModel);
        }
        public async Task<IActionResult> Hayvanlar()
        {
            var hayvanlar = await _hayvanService.Query().Include(x => x.Sahip).ToListAsync();

            return View(hayvanlar);
        }
        public async Task<IActionResult> HayvanDetay(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction("Index");
            }
            var hayvan = await _hayvanService.GetByIdAsync(id);
            if (hayvan == null)
            {
                return RedirectToAction("Index");
            }

            HayvanDetayViewModel viewModel = new HayvanDetayViewModel();

            viewModel.Randevular = await _randevuService.Query()
                                         .Include( x=> x.Musteri )
                                         .Where( x => x.HayvanId == id )
                                         .OrderByDescending( x => x.OlusturmaTarihi )
                                         .Take(5)
                                         .ToListAsync();
            viewModel.HayvanAd = hayvan.Ad;
            viewModel.HayvanCins = hayvan.Cins;
            viewModel.HayvanTur = hayvan.Tur;
            viewModel.HayvanYas = DateTime.Now.Year - hayvan.DogumTarihi.Value.Year;
            viewModel.HayvanKilo = hayvan.Kilo;
            viewModel.KayitTarihi = hayvan.KayitTarihi.ToString("D");
            viewModel.Tedaviler = await _tedaviService.Query()
                                                .Where(x => x.Randevu.HayvanId == id)
                                                .OrderByDescending(x => x.TedaviTarihi)
                                                .Take(5)
                                                .ToListAsync();
            viewModel.ToplamOdeme = await _tedaviService.Query()
                                    .Where(x => x.Randevu.HayvanId == id)
                                    .Select(x => x.Ucret)
                                    .SumAsync();

            var toplamMasraf = viewModel.ToplamOdeme;
            var yapilanOdeme = await _odemeService.Query()
                                    .Where(x => x.Randevu.HayvanId == id)
                                    .Select(x => x.Tutar)
                                    .SumAsync();
            viewModel.KalanBorc = toplamMasraf - yapilanOdeme;

            viewModel.SaglikGecmisi = await _saglikKaydiService.Query()
                                      .Where(x => x.HayvanId == id)
                                      .ToListAsync();
            return View(viewModel);
        }
        public IActionResult HayvanEkle()
        {
            List<SelectListItem> uyeler = (from x in _userManager.Users.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.AdSoyad,
                                                     Value = x.Id.ToString()
                                                 }).ToList();
            ViewBag.uyeler = uyeler;
            return View();
        }

        [HttpPost]
        public IActionResult HayvanEkle(Hayvan entity)
        {
            List<SelectListItem> uyeler = (from x in _userManager.Users.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AdSoyad,
                                               Value = x.Id.ToString()
                                           }).ToList();
            ViewBag.uyeler = uyeler;

            try
            {
                _hayvanService.AddAsync(entity);
            }
            catch (Exception ex)
            {
                TempData["Hata"] = "Ekleme işleminde hata";
            }
            return RedirectToAction("Hayvanlar");

        }

        public async Task<IActionResult> HayvanDuzenle(int id)
        {
            var hayvan = await _hayvanService.GetByIdAsync(id);
            List<SelectListItem> uyeler = (from x in _userManager.Users.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AdSoyad,
                                               Value = x.Id.ToString(),
                                               Selected = ( x.Id == id)
                                           }).ToList();
            ViewBag.uyeler = uyeler;
            return View(hayvan);
        }
        [HttpPost]
        public async Task<IActionResult> HayvanDuzenle(Hayvan entity)
        {
            await _hayvanService.UpdateAsync(entity);
            return RedirectToAction("Hayvanlar");
        }
        
        public async Task<IActionResult> HayvanSil(int id)
        {
            var hayvan = await _hayvanService.GetByIdAsync(id);
            if(hayvan != null)
            {
                try
                {
                    await _hayvanService.RemoveAsync(hayvan);
                    TempData["Mesaj"] = hayvan.Ad + "Başarıyla sistemden silindi";
                }
                catch (Exception ex)
                {
                    TempData["Mesaj"] = null;
                    TempData["Hata"] = hayvan.Ad + " silinemez.";
                }
            }

            return RedirectToAction("Hayvanlar");
        }


        public async Task<IActionResult> Randevular()
        {
            var randevular = await _randevuService.Query()
                 .Include(x => x.Hayvan)
                 .Include(x => x.Tedaviler)
                 .Include(x => x.Musteri)
                 .ToListAsync();
            return View(randevular);
            
        }

        public async Task<IActionResult> RandevuIptal(int id)
        {
            var randevu = await _randevuService.GetByIdAsync(id);
            if (randevu != null)
            {
                await _randevuService.RandevuIptal(randevu.MusteriId, id);
            }
            return RedirectToAction("Randevular");
        }
        [HttpGet]
        public async Task<IActionResult> RandevuDuzenle(int id)
        {
            var randevu = await _randevuService.GetByIdAsync(id);

            if (randevu == null)
            {
                return RedirectToAction("Randevular");
            }

            randevu.Tarih = randevu.RandevuZamani.ToString("yyyy-MM-dd");
            randevu.Saat = randevu.RandevuZamani.ToString("HH:mm");


            var musteriler = _userManager.Users.ToList(); 
            var hayvanlar = await _hayvanService.GetAllAsync();     

            ViewBag.Musteriler = new SelectList(musteriler, "Id", "AdSoyad", randevu.MusteriId);
            ViewBag.Hayvanlar = new SelectList(hayvanlar, "Id", "Ad", randevu.HayvanId);

            return View(randevu);
        }

        [HttpPost]
        public async Task<IActionResult> RandevuDuzenle(Randevu entity)
        {
            try
            {
                var date = DateTime.Parse(entity.Tarih); 
                var time = TimeSpan.Parse(entity.Saat);   

                entity.RandevuZamani = date.Date.Add(time);
                await _randevuService.UpdateAsync(entity);
                TempData["Mesaj"] = "Basariyla duzenlendi";
            }
            catch (Exception ex)
            {
                TempData["Mesaj"] = "Düzenleme basarisiz";
            }
           
            
            return RedirectToAction("Randevular");
        }

        public IActionResult RandevuOlustur()
        {
            var musteriler = _userManager.Users
                .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.AdSoyad })
                .ToList();

            ViewBag.Musteriler = musteriler;

            // Hayvan dropdown'ı ilk etapta boş gelecek
            ViewBag.Hayvanlar = new List<SelectListItem>();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RandevuOlustur(Randevu entity)
        {

            var date = DateTime.Parse(entity.Tarih);  
            var time = TimeSpan.Parse(entity.Saat);   

            entity.RandevuZamani = date.Date.Add(time);

            await _randevuService.AddAsyc(entity);

            return RedirectToAction("Randevular");

        }

        public IActionResult HayvanGetir(int musteriId)
        {
            var animals = _hayvanService.Query()
                .Where(x => x.SahipId == musteriId)
                .Select(x => new { id = x.Id, ad = x.Ad })
                .ToList();

            return Json(animals);
        }


        public IActionResult GetTedavi(int id)
        {

            var tedavi = _tedaviService.Query()
                        .Include(x => x.Randevu.Musteri)
                        .Include(x => x.Randevu)
                        .ThenInclude(r => r.Hayvan)
                        .FirstOrDefault(x => x.Id == id);
            if (tedavi == null)
            {
                return NotFound();
            }
            return Json(new
            {
                id = tedavi.Id,
                tedaviTuru = tedavi.TedaviTuru,
                ucret = tedavi.Ucret,
                notlar = tedavi.Aciklama,
                TedaviTarihi = tedavi.TedaviTarihi,
            });

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTedavi(Tedavi model)
        {


            var tedavi = await _tedaviService.GetByIdAsync(model.Id);
            if (tedavi == null)
                return NotFound();

            tedavi.TedaviTuru = model.TedaviTuru;
            tedavi.Ucret = model.Ucret;
            tedavi.Aciklama = model.Aciklama; // alan adına göre uyarlarsın
            await _tedaviService.UpdateAsync(tedavi);


            return RedirectToAction("Tedaviler");
        }


        public async Task<IActionResult> Tedaviler()
        {
            var tedaviler = await _tedaviService.Query().Include(x => x.Randevu.Musteri)
                                  .Include(x => x.Randevu)
                                  .ThenInclude(r => r.Hayvan)
                                  .ToListAsync();

            var randevular = await _randevuService
                .Query()
                .Include(r => r.Hayvan)
                .Where(r => !r.Tedaviler.Any())
                .ToListAsync();

            var randevularS = new SelectList(
                randevular.Select(r => new
                {
                    r.Id,
                    HayvanAd = r.Hayvan.Ad
                }),
                "Id",
                "HayvanAd"
            );
            ViewBag.randevular = randevularS;

            return View(tedaviler);
        }


        public async Task<IActionResult> TedaviSil(int id)
        {
            var tedavi = await _tedaviService.GetByIdAsync(id);
            if (tedavi == null)
            {
                return NotFound();
            }
            await _tedaviService.RemoveAsync(tedavi);
            return RedirectToAction("Tedaviler");
        }

        [HttpPost]
        public async Task<IActionResult> TedaviEkle(Tedavi entity)
        {
            entity.TedaviTarihi = DateTime.Now;
            await _tedaviService.AddAsync(entity);
            return RedirectToAction("Tedaviler");
        }
        public async Task<IActionResult> Odemeler()
        {
            OdemelerViewModel viewModel = new OdemelerViewModel();

            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);
            var firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
            var firstDayOfYear = new DateTime(today.Year, 1, 1);

            // Bu ay toplam
            viewModel.BuAyToplam = await _odemeService.Query()
                .Where(x => x.OdemeTarihi >= firstDayOfMonth)
                .SumAsync(x => x.Tutar);

            // Bugün alınan
            viewModel.BugunAlinan = await _odemeService.Query()
                .Where(x => x.OdemeTarihi >= today && x.OdemeTarihi < tomorrow)
                .SumAsync(x => x.Tutar);

            viewModel.BugunIslemSayisi = await _odemeService.Query()
                .Where(x => x.OdemeTarihi >= today && x.OdemeTarihi < tomorrow)
                .CountAsync();

            // Bekleyen borç hesaplama
            var toplamTedaviUcreti = await _tedaviService.Query().SumAsync(x => x.Ucret);
            var toplamOdeme = await _odemeService.Query().SumAsync(x => x.Tutar);
            viewModel.BekleyenBorc = toplamTedaviUcreti - toplamOdeme;

            // Borçlu müşteri sayısı
            var borcluRandevular = await _randevuService.Query()
                .Include(r => r.Tedaviler)
                .Include(r => r.Odemeler)
                .Where(r => r.Tedaviler.Sum(t => t.Ucret) > r.Odemeler.Sum(o => o.Tutar))
                .Select(r => r.MusteriId)
                .Distinct()
                .CountAsync();
            viewModel.BorcluMusteriSayisi = borcluRandevular;

            // Yıllık toplam
            viewModel.YillikToplam = await _odemeService.Query()
                .Where(x => x.OdemeTarihi >= firstDayOfYear)
                .SumAsync(x => x.Tutar);

            // Tüm ödemeler
            viewModel.Odemeler = await _odemeService.Query()
                .Include(x => x.Randevu)
                    .ThenInclude(r => r.Hayvan)
                .Include(x => x.Randevu)
                    .ThenInclude(r => r.Musteri)
                .Include(x => x.Randevu)
                    .ThenInclude(r => r.Tedaviler)
                .OrderByDescending(x => x.OdemeTarihi)
                .ToListAsync();

            // Randevular dropdown için
            var randevularWithDebt = await _randevuService.Query()
                .Include(r => r.Hayvan)
                .Include(r => r.Tedaviler)
                .Include(r => r.Odemeler)
                .Where(r => r.Tedaviler.Sum(t => t.Ucret) > r.Odemeler.Sum(o => o.Tutar))
                .ToListAsync();

            var randevularS = new SelectList(
                randevularWithDebt.Select(r => new
                {
                    r.Id,
                    Display = $"#{r.Id} - {r.Hayvan.Ad} (Borç: ₺{r.Tedaviler.Sum(t => t.Ucret) - r.Odemeler.Sum(o => o.Tutar)})"
                }),
                "Id",
                "Display"
            );
            ViewBag.randevular = randevularS;

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> OdemeKaydet(Odeme entity)
        {
            var randevu = await _randevuService.GetByIdAsync(entity.RandevuId);
            if (randevu != null)
            {
                entity.MusteriId = randevu.MusteriId;
            }

            await _odemeService.AddAsync(entity);
            return RedirectToAction("Odemeler");
        }

        public async Task<IActionResult> OdemeSil(int id)
        {
            var odeme = await _odemeService.GetByIdAsync(id);
            if (odeme != null)
            {
                await _odemeService.RemoveAsync(odeme);
            }
            return RedirectToAction("Odemeler");
        }
    }
}
