using Application.Bookings.Queries.GetBookings;
using Application.Common.Interfaces;
using Application.Services.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Bookings.Commands
{
    public class CreateBookingCommand : IRequest<BookingDto>
    {
        public DateTime FromDateTime { get; set; }
        public DateTime ReturnDateTime { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public int PickUpLocationId { get; set; }
        public int DropOffLocationId { get; set; }
        public int PackageId { get; set; }
        
        

    }

    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, BookingDto>
    {
        public readonly IBookingService _bookingService;

        public CreateBookingCommandHandler(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public Task<BookingDto> Handle(CreateBookingCommand command, CancellationToken cancellationToken)
        {
            return _bookingService.CreateNewBookingAsync(command, cancellationToken);
        }
    }
}