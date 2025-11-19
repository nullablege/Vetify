using BL.Abstract;
using EL.Entities;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Vetify.Models.ViewModel;

namespace Vetify.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly IRandevuService _randevuService;
        private readonly IHayvanService _hayvanService;
        private readonly IOdemeService _odemeService;
        private readonly ITedaviService _tedaviService;
        private readonly ISaglikKaydiService _saglikKaydiService;
        private readonly UserManager<Kullanici> _userManager;

        public CustomerController(IRandevuService randevuService, 
                                  IHayvanService hayvanService,    
                                  IOdemeService odemeService, 
                                  ITedaviService tedaviService, 
                                  ISaglikKaydiService saglikKaydiService,
                                  UserManager<Kullanici> userManager)
        {
            _randevuService = randevuService;
            _hayvanService = hayvanService;
            _odemeService = odemeService;
            _tedaviService = tedaviService;
            _saglikKaydiService = saglikKaydiService;
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
            var userId = GetUserId();

            CustomerDashboardViewModel viewModel = new CustomerDashboardViewModel();

            viewModel.ToplamHayvan = await _hayvanService
                .Query()
                .Where(x => x.SahipId == userId)
                .CountAsync();

            viewModel.planlanmisRandevu = await _randevuService
                .Query()
                .Where(x => x.MusteriId == userId && x.Durum == EL.Enums.RandevuDurum.Planlandi )
                .CountAsync();

            viewModel.son30OdemeTutar = await _odemeService.Query()
                                        .Where(x => x.MusteriId == userId && x.OdemeTarihi >= DateTime.Now.AddDays(-30)).Select(x => x.Tutar)
                                        .SumAsync();
            viewModel.son30TedaviSayisi = await _tedaviService.Query().
                                                Where(x => x.Randevu.MusteriId == userId && x.TedaviTarihi >= DateTime.Now.AddDays(-30)).
                                                CountAsync();
            viewModel.son30OdemeSayisi = await _odemeService.Query().
                                               Where(x => x.MusteriId == userId && x.OdemeTarihi >= DateTime.Now.AddDays(-30)).
                                               CountAsync();
            var odemeTutari = await _odemeService.Query().
                                    Where(x => x.MusteriId == userId ).
                                    Select(x => x.Tutar).
                                    SumAsync();
            var odenecekTutar = await _tedaviService.Query().
                                      Where(x => x.Randevu.MusteriId == userId ).
                                      Select(x => x.Ucret).
                                      SumAsync();
            viewModel.guncelBorc = odenecekTutar - odemeTutari;

            viewModel.sonRandevular = await _randevuService.Query().Include(x => x.Hayvan).OrderByDescending(x => x.OlusturmaTarihi).Take(5).ToListAsync();

            return View(viewModel);
        }

        public async Task<IActionResult> Hayvanlarim()
        {
            var userId = GetUserId();

            var hayvanlar = await _hayvanService.Query().
                                  Where(x => x.SahipId == userId).
                                  ToListAsync();

            return View(hayvanlar);
        }

        public async Task<IActionResult> HayvanDetay(int id)
        {
            var userId = GetUserId();
            if (id <= 0)
            {
                return RedirectToAction("Index");
            }
            var hayvan = await _hayvanService.GetByIdAsync(id);
            if(hayvan == null)
            {
                return RedirectToAction("Index");
            }
            if(userId != hayvan.SahipId)
            {
                return Forbid();
            }
            HayvanDetayViewModel viewModel = new HayvanDetayViewModel();

            viewModel.Randevular = await _randevuService.Query()
                                         .Where(x => x.HayvanId == id)
                                         .OrderByDescending(x => x.OlusturmaTarihi)
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

        public async Task<IActionResult> Randevularim()
        {
            var userId = GetUserId();

            var randevular = await _randevuService.Query()
                             .Include(x => x.Hayvan)
                             .Include(x => x.Tedaviler)
                             .Where(x => x.Hayvan.SahipId == userId)
                             .ToListAsync();
            return View(randevular);
        }


        public async Task<IActionResult> RandevuIptal(int id)
        {
            await _randevuService.RandevuIptal(GetUserId(), id);
            return RedirectToAction("Randevularim");
        }

        public async Task<IActionResult> Tedavilerim()
        {
            var userId = GetUserId();
            var tedaviler = await _tedaviService.Query().
                                  Include(x => x.Randevu).
                                  Include(x => x.Randevu.Hayvan).
                                  Where(x => x.Randevu.MusteriId == userId).
                                  ToListAsync();

            return View(tedaviler);
        }

        public async Task<IActionResult> Odemelerim()
        {
            OdemeViewModel viewModel = new OdemeViewModel();
            viewModel.Odemeler = await _odemeService.Query()
                                .Where(x => x.MusteriId == GetUserId())
                                .Include(x => x.Randevu)
                                .Include( x=>x.Randevu.Hayvan)
                                .ToListAsync();
            viewModel.ToplamOdenecek = _randevuService.Query()
                                        .Include(x => x.Tedaviler)
                                        .Where(x => x.MusteriId == GetUserId())
                                        .SelectMany(x => x.Tedaviler)
                                        .Sum(t => t.Ucret);
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult HayvanEkle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> HayvanEkle(Hayvan entity)
        {
            entity.SahipId = GetUserId();
            await _hayvanService.AddAsync(entity);

            return RedirectToAction("Hayvanlarim");
        }

        [HttpGet]
        public IActionResult RandevuAl()
        {
            List<SelectListItem> itemler = (from x in _hayvanService.Query().Where(x => x.SahipId == GetUserId()).ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.Ad,
                                                Value = x.Id.ToString()
                                            }).ToList();
            ViewBag.itemler = itemler;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RandevuAl(Randevu entity)
        {
            var date = DateTime.Parse(entity.Tarih);
            var time = TimeSpan.Parse(entity.Saat);

            entity.RandevuZamani = date.Date.Add(time);
            entity.MusteriId = GetUserId();

            await _randevuService.AddAsyc(entity);

            return RedirectToAction("Randevularim");
        }
    }
}
