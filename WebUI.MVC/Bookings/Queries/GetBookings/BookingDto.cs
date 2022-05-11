using System;

namespace Application.Bookings.Queries.GetBookings
{
    public class BookingDto : IMapFrom<BookingEntity>
    {
        private void Mapping(Profile profile)
        {
            profile.CreateMap<BookingEntity, BookingDto>();
        }

        public DateTime? Date { get; set; }
        public string Name { get; set; }
        public CarEntity Car { get; set; }
    }
}