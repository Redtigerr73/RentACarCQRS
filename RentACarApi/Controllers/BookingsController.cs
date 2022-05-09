using Application.Booking.Commands;
using Application.Booking.Queries.GetBookings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RentACarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : MediatorController
    {
        [HttpGet]
        public async Task<ActionResult<BookingsVm>> Get()
        {
            return await Mediator.Send(new GetBookingsQuery());
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateBookingCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
