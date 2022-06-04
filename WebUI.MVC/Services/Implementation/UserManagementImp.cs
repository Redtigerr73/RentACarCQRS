using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebUI.MVC.Models;
using WebUI.MVC.Services.Interfaces;

namespace WebUI.MVC.Services.Implementation
{
    public class UserManagementImp : IUserManagement
    {
        
        private readonly HttpClient _httpClient;
        private IConfiguration _configuration;

        public UserManagementImp(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }


        public async Task<Auth0Entity> CreateUser(User user)
        {
            var token = await GetToken();
            var accessToken = token.AccessToken;
            var endPoint = _configuration["UserManagementAPI:Audience"]+"users";
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var authEntity = new Auth0Entity(user.Email, user.FirstName, user.LastName,user.Email, _configuration);
            var content = JsonConvert.SerializeObject(authEntity);

            var response = await _httpClient.PostAsync(endPoint, new StringContent(content, Encoding.Default, "application/json"));
            if(!response.IsSuccessStatusCode)
            {
                throw new Exception("Could not create user ");
            }

            return authEntity;

        }

        public async Task<List<UserVm>> GetAllUsers(CancellationToken cancellationToken)
        {
            var token = await GetToken();
            var accessToken = token.AccessToken;
            var endPoint = _configuration["UserManagementAPI:GetUsersPath"];
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _httpClient.GetAsync(endPoint, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Unable to retrieve Users Data");
            }

            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            var users = JsonConvert.DeserializeObject<List<UserVm>>(content);
            return users;
        }

        public async Task<TokenData> GetToken()
        {
            var response =
                await _httpClient.PostAsync(_configuration["UserManagementAPI:AuthPath"], new FormUrlEncodedContent(
                    new Dictionary<string, string>
                    {
                        { "client_id", _configuration["UserManagementAPI:ClientId"] },
                        { "grant_type", _configuration["UserManagementAPI:GrantType"] },
                        { "client_secret", _configuration["UserManagementAPI:ClientSecret"] },
                        { "audience", _configuration["UserManagementAPI:Audience"] },
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
