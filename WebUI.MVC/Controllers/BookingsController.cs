using Microsoft.AspNetCore.Authentication;
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
            var bookings = await _service.GetAllAsync(await HttpContext.GetTokenAsync("access_token"));
            return View(bookings);
        }


        public IActionResult Create()
        {
            return View();
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

      
        
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            var booking = await _service.BookingDetailsAsync(id);
            if (booking == null)
                return NotFound();
            return View(booking);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Booking booking)
        {
            await _service.UpdateBookingAsync(id, booking);

            return RedirectToAction("All");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                NotFound();
            }
            var booking = await _service.BookingDetailsAsync(id);
            return View(booking);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            await _service.DeleteBookingAsync(id);
            return RedirectToAction("All");
        }



    }
}