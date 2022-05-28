using Application.Common.Models;
using Application.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.FuelPrices.Queries
{
    public class GetFuelPricesQuery : IRequest<FuelPriceData>
    {
    }

    public class GetFuelPricesQueryHandler : IRequestHandler<GetFuelPricesQuery,FuelPriceData>
    {
        private readonly IApiConsume _apiConsume;

        public GetFuelPricesQueryHandler(IApiConsume apiConsume)
        {
            _apiConsume = apiConsume;
        }

        public async Task<FuelPriceData> Handle(GetFuelPricesQuery request, CancellationToken cancellationToken)
        {
            return await _apiConsume.GetFuelPriceDataAsync(cancellationToken);
        }
    }
}
