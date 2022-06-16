using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebUI.MVC.Models;
using WebUI.MVC.Services.Interfaces;

namespace WebUI.MVC.Controllers
{
    public class BookingsController : Controller
    {
        private readonly IBookingService _service;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public readonly IUserManagement _userManagement;


        public BookingsController(IBookingService service, IHttpContextAccessor httpContextAccessor, IUserManagement userManagement)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
            _userManagement = userManagement;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> All()
        {
            var bookings = await _service.GetAllAsync(await HttpContext.GetTokenAsync("access_token"));

            var idUser = "";
            if (User.Identity.IsAuthenticated)
            {
                string accessToken = await HttpContext.GetTokenAsync("access_token");
                DateTime accessTokenExpiresAt = DateTime.Parse(
                    await HttpContext.GetTokenAsync("expires_at"),
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.RoundtripKind
                    );

                string idtoken = await HttpContext.GetTokenAsync("id_token");
                idUser = _httpContextAccessor.HttpContext.User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;

                var userRoles = await _userManagement.GetUserRoles(idUser);
                var str = userRoles[0].Name;
                TempData["Role"] = str;
                TempData["UserName"] = _httpContextAccessor.HttpContext.User.Claims.ElementAt(0).Value;
            }

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
            await _service.CreateAsync(booking, await HttpContext.GetTokenAsync("access_token"));
            TempData["Message"] = "Success : Booking has been created";
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
            TempData["Message"] = "Success : Booking has been updated";
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
            TempData["Message"] = "Warning : Booking has been deleted";
            return RedirectToAction("All");
        }



    }
}