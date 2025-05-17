using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Giriş yapan kullanıcının adını al
            string? userName = User.Identity?.Name;

            ViewBag.UserName = userName;

            ViewData["Title"] = "Welcome";
            return View();
        }
    }
}