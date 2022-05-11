using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;

namespace Application.Bookings.Queries.GetBookings
{
    public class BookingDto : IMapFrom<Booking>
    {
        private void Mapping(Profile profile)
        {
            profile.CreateMap<Booking, BookingDto>();
        }

        public DateTime FromDateTime { get; set; }
        public DateTime ReturnDateTime { get; set; }
        public string Status { get; set; }
        public double Amount { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public int? InvoiceId { get; set; }
        //public virtual Car Car { get; set; }
        //public virtual Customer Customer { get; set; }
        //public virtual Location DropOffLocation { get; set; }
        //public virtual Invoice Invoice { get; set; }
        //public virtual Package Package { get; set; }
        ////public virtual Location PickUpLocation { get; set; }
    }
}