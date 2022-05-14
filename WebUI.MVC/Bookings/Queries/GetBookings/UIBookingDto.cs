using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;

namespace Application.Bookings.Queries.GetBookings
{
    public class UIBookingDto : IMapFrom<Booking>
    {
        private void Mapping(Profile profile)
        {
            profile.CreateMap<Booking, UIBookingDto>();
        }

        public DateTime? Date { get; set; }
        public string Name { get; set; }
        public Car Car { get; set; }
    }
}