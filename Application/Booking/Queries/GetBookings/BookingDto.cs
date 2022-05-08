using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Booking.Queries.GetBookings
{
    public  class BookingDto: IMapFrom<BookingEntity>
    {
        public DateTime? Date { get; set; }     
        public string Note { get; set; }
        public CarEntity Car { get; set; }
    }
}
