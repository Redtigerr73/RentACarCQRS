using Application.Common.CustomErrors;
using Application.Common.Interfaces;
using Application.Services.Implementations;
using Application.Services.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Bookings.Commands
{
    public class UpdateBookingCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int PickUpLocationId { get; set; }
        public int DropOffLocationId { get; set; }
    }

    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, int>
    {

        private readonly IBookingService _service;

        public UpdateBookingCommandHandler(IBookingService service)
        {
            _service = service;
        }

        public async Task<int> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            return await _service.UpdateBookingAsync(request, cancellationToken);


        }
    }
}