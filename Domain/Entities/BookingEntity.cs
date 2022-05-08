using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BookingEntity
    {
        public DateTime? Date { get; set; }
        public CarEntity Car { get; set; }

        public string Note { get; set; }    

        public bool IsPayed { get; set; }


    }
}
