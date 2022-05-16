using Microsoft.AspNetCore.Mvc;
using RentACarApi.Controllers;

namespace WebUI.MVC.Controllers
{
    public class UIBookingsController : Controller
    {
        public readonly BookingsController _controller;

        public UIBookingsController(BookingsController controller)
        {
            _controller = controller;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Bookings()
        {
            var bookings = _controller.Get();
            return View(bookings);
        }
    }
}