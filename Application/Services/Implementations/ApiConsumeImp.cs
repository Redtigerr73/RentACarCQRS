using Application.Common.Models;
using Application.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Implementations
{
    public class ApiConsumeImp : IApiConsume

    {

		public readonly IHttpClientFactory _httpClientFactory;

		public ApiConsumeImp(IHttpClientFactory clientFactory)
		{
			_httpClientFactory = clientFactory;
		}

        public async Task<FuelPriceData> GetFuelPriceDataAsync(CancellationToken cancellationToken)
        {
			var client = _httpClientFactory.CreateClient("PolicyCircuitBreaker");
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://gas-price.p.rapidapi.com/europeanCountries"),
				Headers =
				{
					{ "X-RapidAPI-Host", "gas-price.p.rapidapi.com" },
					{ "X-RapidAPI-Key", "26d1200e4bmshfa1a53e4b6b905bp16d174jsnf58a36735c35" },
				},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync(cancellationToken);
				var list = JsonConvert.DeserializeObject<FuelPriceData>(body);
				return list; 
			}
		}
    }
}
