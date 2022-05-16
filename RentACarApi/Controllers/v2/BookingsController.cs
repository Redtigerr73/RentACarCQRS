using Application.Bookings.Commands;
using Application.Bookings.Queries.GetBookings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RentACarApi.Controllers.v2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class BookingsController : MediatorController
    {
        [HttpGet]
        public async Task<ActionResult<BookingsVm>> Get()
        {
            return await Mediator.Send(new GetBookingsQuery());
        }

        [Route("create")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<BookingDto>> Create(CreateBookingCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateBookingCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteBookingCommand { Id = id });

            return NoContent();
        }
    }
}