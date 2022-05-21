using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebUI.MVC.Models;
using WebUI.MVC.Services.Interfaces;

namespace WebUI.MVC.Controllers
{
    public class BookingsController : Controller
    {
        private readonly IBookingService _service;

        public BookingsController(IBookingService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        
        public async Task<IActionResult> All()
        {
            var bookings = await _service.GetAllAsync();
            return View(bookings);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Booking booking)
        {
            await _service.CreateAsync(booking);
            return RedirectToAction("All");
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            var booking = await _service.BookingDetailsAsync(id);
            return View(booking);
        }

        public IActionResult Create()
        {
            return View();
        }
        
    }
}