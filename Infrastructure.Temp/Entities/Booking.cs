﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Booking
    {
        public int Id { get; set; }
        public DateTime FromDateTime { get; set; }
        public DateTime ReturnDateTime { get; set; }
        public string Status { get; set; }
        public double Amount { get; set; }
        public double CountryCostPerKm { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public int? InvoiceId { get; set; }
        public int? PackageId { get; set; }
        public int PickUpLocationId { get; set; }
        public int DropOffLocationId { get; set; }
        public DateTime? ModificationDateTime { get; set; }
        public DateTime? CancellationDateTime { get; set; }

        public virtual Car Car { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Location DropOffLocation { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual Package Package { get; set; }
        public virtual Location PickUpLocation { get; set; }
    }
}