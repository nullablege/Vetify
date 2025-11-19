using BL.Abstract;
using EL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Vetify.Models.ViewModel;
using System.Security.Claims;

namespace Vetify.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<Kullanici> _userManager;
        private readonly SignInManager<Kullanici> _signInManager;

        // private readonly IKullaniciService _kullaniciManager;

        public AccountController(UserManager<Kullanici> userManager, SignInManager<Kullanici> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index() => RedirectToAction("Login");
        public IActionResult Login() => View("Login");

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model) 
        {
            if (!ModelState.IsValid) return View(model);

            
            var user = await _userManager.FindByEmailAsync(model.Eposta); //Username'ı e posta olarak kullanıyoruz
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Geçersiz giriş denemesi.");
                return View(model);
            }


            var result = await _signInManager.PasswordSignInAsync(user, model.Sifre, model.BeniHatirla, false);

            if (result.Succeeded)
            {
                if(await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    //Admin mi ?
                    return RedirectToAction("Index", "Vet");
                }
                if(await _userManager.IsInRoleAsync(user, "Customer"))
                {
                    //Customer mi ? 
                    return RedirectToAction("Index", "Customer");
                }
                return View();
            }

            ModelState.AddModelError(string.Empty, "Geçersiz giriş denemesi.");
            return View(model);
        }

        public IActionResult Register()
        {

         return View("Register");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model) 
        {
            
            if (!ModelState.IsValid) return View(model);

            var kullanici = new Kullanici
            {
                AdSoyad = model.AdSoyad,
                Email = model.Eposta,
                UserName = model.Eposta, 
                OlusturmaTarihi = DateTime.Now,
                PhoneNumber = model.PhoneNumber,

            };

            
            var result = await _userManager.CreateAsync(kullanici, model.Sifre);

            if (result.Succeeded)
            {
                // Oluşan kullanıcıya Customer rolu veriyoruz.
                await _userManager.AddToRoleAsync(kullanici, "Customer");

                // Kullanıcıyı oluşturduktan sonra hemen giriş yaptır
                await _signInManager.SignInAsync(kullanici, isPersistent: false);
                return RedirectToAction("Index", "Customer");
            }

            // Hatayı Model'e ekle
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync(); // Çıkış yap
            return RedirectToAction("Index", "Home");
        }
    }
}