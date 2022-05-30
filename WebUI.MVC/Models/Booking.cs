using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebUI.MVC.Models
{
    [Serializable]
    public class Booking
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A Pickup date is needed")]
        [DisplayName("Pickup Date")]
        public DateTime FromDateTime { get; set; }
        [Required(ErrorMessage = "A Dropoff date is needed")]
        [DisplayName("Dropoff Date")]
        public DateTime ReturnDateTime { get; set; }
        [Required(ErrorMessage = "A Pickup location is needed")]
        [Range(1, 12, ErrorMessage = "Location must be between 1 and 12")]
        [DisplayName("Pickup Location")]
        public int PickUpLocationId { get; set; }
        [Required(ErrorMessage = "A Dropoff location is needed")]
        [Range(1, 12, ErrorMessage = "Location must be between 1 and 12")]
        [DisplayName("Dropoff Location")]
        public int DropOffLocationId { get; set; }
        public string Status { get; set; }
        public double Amount { get; set; }
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "A Car identification is needed")]
        [Range(1, 1082, ErrorMessage = "Identification must be between 2 and 40")]
        [DisplayName("Car identifier")]
        public int CarId { get; set; }
        public int? InvoiceId { get; set; }
        public int? PackageId { get; set; }
    }

    
    public class Bookings
    {
        [JsonProperty("bookings")]
        public List<Booking> BookingList { get; set; }
    }
}
