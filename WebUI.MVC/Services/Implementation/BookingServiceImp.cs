using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebUI.MVC.Models;
using WebUI.MVC.Services.Interfaces;

namespace WebUI.MVC.Services.Implementation
{
    public class BookingServiceImp : IBookingService
    {
        private  string BaseUrl;
        private readonly HttpClient _httpClient;

        public BookingServiceImp(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            BaseUrl = configuration["BaseUrl"];
        }

        public async Task<Bookings> GetAllAsync()
        {
            var httpResponse = await _httpClient.GetAsync($"{BaseUrl}/api/v1/bookings");
            if(!httpResponse.IsSuccessStatusCode)
            {
                throw new System.Exception("Cannot retrieve bookings");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var bookings = JsonConvert.DeserializeObject<Bookings>(content);
            return bookings;
        }
    }
}
