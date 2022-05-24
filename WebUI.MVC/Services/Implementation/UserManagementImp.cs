using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebUI.MVC.Models;
using WebUI.MVC.Services.Interfaces;

namespace WebUI.MVC.Services.Implementation
{
    public class UserManagementImp : IUserManagement
    {
        private string BaseUrl;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public UserManagementImp(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            BaseUrl = configuration["BaseUrl"];
            _configuration = configuration;
        }


        public Task CreateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public async Task<TokenData> GetToken()
        {
            var response =
                await _httpClient.PostAsync(_configuration["Auth0ManagementApi:Path"], new FormUrlEncodedContent(
                    new Dictionary<string, string>
                    {
                        { "client_id", _configuration["Auth0ManagementApi:ClientId"] },
                        { "grant_type", _configuration["Auth0ManagementApi:GrantType"] },
                        { "client_secret", _configuration["Auth0ManagementApi:ClientSecret"] },
                        { "audience", _configuration["Auth0ManagementApi:Audience"] },
                    }));
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Unable to retrieve access token");
            }
            var content = await response.Content.ReadAsStringAsync();
            var tokenData = JsonConvert.DeserializeObject<TokenData>(content);
            return tokenData;
        }
    }
}
