using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IApiConsume
    {
        Task<FuelPriceData> GetFuelPriceDataAsync(CancellationToken cancellationToken);
    }
}
