using Application.Bookings.Commands;
using Application.Bookings.Queries.GetBookings;
using Application.Common.Models;
using Application.Features.Bookings.Queries.GetBookings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;

namespace RentACarApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class BookingsController : MediatorController
    {
        [HttpGet]
        [Authorize("read:bookings")]
        public async Task<ActionResult<BookingsVm>> Get()
        {
            return await Mediator.Send(new GetBookingsQuery());
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<BookingDto>> GetBooking(int id)
        {
            return await Mediator.Send(new GetBookingByIdQuery(id));
        }

        [Route("create")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Authorize("write:bookings")]
        public async Task<ActionResult<BookingDto>> Create(CreateBookingCommand command)
        {
            var entity = await Mediator.Send(command);
            return entity;
            //return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
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
        [Route("paginatedBookings")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<Pagination<BookingDto>>> PaginatedResult([FromQuery]GetPaginatedBookingsQuery query)
        {
            return await Mediator.Send(query);
        }
    }

}



