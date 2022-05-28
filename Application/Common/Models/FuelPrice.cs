using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    [Serializable]
    public class FuelPrice
    {
        public string currency { get; set; }
        public string lpg { get; set; }
        public string diesel { get; set; }
        public string gasoline { get; set; }
        public string Country { get; set; }
    }
    public class FuelPriceData
    {
        public IQueryable<FuelPrice> results { get; set; }
        public bool success { get; set; }
    }
}
