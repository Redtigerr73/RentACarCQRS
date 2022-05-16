using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebUI.MVC.Models;

namespace WebUI.MVC.Services.Interfaces
{
    public interface IBookingService
    {
        Task<Bookings> GetAllAsync();
    }
}
