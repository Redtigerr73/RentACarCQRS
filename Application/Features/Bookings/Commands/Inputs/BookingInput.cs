using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Bookings.Commands.Inputs
{
    public class BookingInput
    {
        public DateTime FromDateTime { get; set; } = DateTime.Today;
        public DateTime ReturnDateTime { get; set; } = DateTime.Today;
        public int CustomerId { get; set; } 
        public int CarId { get; set; }
        public int PickUpLocationId { get; set; } 
        public int DropOffLocationId { get; set; } 


    }
}
