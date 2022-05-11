using Microsoft.AspNetCore.Mvc;

namespace WebUI.MVC.Controllers
{
    public class BookingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}