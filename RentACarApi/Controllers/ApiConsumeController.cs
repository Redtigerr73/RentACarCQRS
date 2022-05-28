using Application.Common.Models;
using Application.Features.FuelPrices.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiConsumeController : MediatorController
    {
        [HttpGet]
        public async Task<FuelPriceData> GetFuelPriceData([FromQuery] GetFuelPricesQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
