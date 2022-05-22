using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebUI.MVC.Models;
using WebUI.MVC.Services.Interfaces;

namespace WebUI.MVC.Services.Implementation
{
    public class BookingServiceImp : IBookingService
    {
        private string BaseUrl;
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

        public async Task<Booking> CreateAsync(Booking booking)
        {
            var json = JsonConvert.SerializeObject(booking);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResponse = await _httpClient.PostAsync($"{BaseUrl}/api/v1/bookings/create", content);
            if(!httpResponse.IsSuccessStatusCode)
            {
                throw new System.Exception("Cannot create the booking");
            }

            return booking;
        }

        public async Task<Booking> BookingDetailsAsync(int? id)
        {
            
            var httpResponse = await _httpClient.GetAsync($"{BaseUrl}/api/v1/bookings/{id}");
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new System.Exception("Cannot retrieve the booking");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var booking = JsonConvert.DeserializeObject<Booking>(content);
            return booking;
        }

        public async Task<Booking> UpdateBookingAsync(int? id, Booking booking)
        {
            var json = JsonConvert.SerializeObject(booking);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResponse = await _httpClient.PutAsync($"{BaseUrl}/api/v1/bookings/{id}", content);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new System.Exception("Cannot create the booking");
            }

            var responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            return booking;
        }

        public async Task DeleteBookingAsync(int? id)
        {
            var httpResponse = await _httpClient.DeleteAsync($"{BaseUrl}/api/v1/bookings/{id}");
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot delete requested Id");
            }
        }






        //private static async Task PostBasicAsync(object content, CancellationToken cancellationToken)
        //{
        //    using (var client = new HttpClient())
        //    using (var request = new HttpRequestMessage(HttpMethod.Post, Url))
        //    {
        //        var json = JsonConvert.SerializeObject(content);
        //        using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
        //        {
        //            request.Content = stringContent;
        //            using (var response = await client
        //                .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
        //                .ConfigureAwait(false))
        //            {
        //                response.EnsureSuccessStatusCode();
        //            }
        //        }
        //    }


    }
}
