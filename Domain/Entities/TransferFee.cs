// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class TransferFee
    {
        public TransferFee()
        {
            Packages = new HashSet<Package>();
        }

        public int Id { get; set; }
        public int PickUpLocationId { get; set; }
        public int DropOffLocationId { get; set; }
        public double FlatRate { get; set; }

        public virtual Location DropOffLocation { get; set; }
        public virtual Location PickUpLocation { get; set; }
        public virtual ICollection<Package> Packages { get; set; }
    }
}