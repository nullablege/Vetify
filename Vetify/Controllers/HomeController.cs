using Microsoft.AspNetCore.Mvc;

namespace Vetify.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return RedirectToAction("Login", "Account");
        }

        public IActionResult DashBoard()
        {
            return View();
        }
    }
}
