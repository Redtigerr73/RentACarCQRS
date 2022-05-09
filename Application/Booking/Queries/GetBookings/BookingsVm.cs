using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Booking.Queries.GetBookings
{
    public class BookingsVm
    {
        public IList<BookingDto> Bookings { get; set; }
    }
}
