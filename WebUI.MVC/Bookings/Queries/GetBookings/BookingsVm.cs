using System.Collections.Generic;

namespace Application.Bookings.Queries.GetBookings
{
    public class BookingsVm
    {
        public IList<BookingDto> Bookings { get; set; }
    }
}