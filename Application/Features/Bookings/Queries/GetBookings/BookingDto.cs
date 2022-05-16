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

        public int Id { get; set; }
        public DateTime FromDateTime { get; set; }
        public DateTime ReturnDateTime { get; set; }
        public int PickUpLocationId { get; set; }
        public int DropOffLocationId { get; set; }
        public string Status { get; set; }
        public double Amount { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public int? InvoiceId { get; set; }

        public int? PackageId { get; set; }

        /// 
        /// Ignored properties from Deserialization
        /// 
        /*[JsonIgnore]
        public virtual Car Car { get; set; }
        [JsonIgnore]
        public virtual Customer Customer { get; set; }
        [JsonIgnore]
        public virtual Location DropOffLocation { get; set; }
        [JsonIgnore]
        public virtual Invoice Invoice { get; set; }
        [JsonIgnore]
        public virtual Package Package { get; set; }
        [JsonIgnore]
        public virtual Location PickUpLocation { get; set; }*/
    }
}