using Application.Common.CustomErrors;
using Application.Common.Interfaces;
using Application.Services.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Bookings.Commands
{
    public class DeleteBookingCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand>
    {
        private readonly IBookingService _bookingService;

        public DeleteBookingCommandHandler(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public async Task<Unit> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            await _bookingService.DeleteBookingAsync(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}