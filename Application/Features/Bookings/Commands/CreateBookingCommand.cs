using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Bookings.Commands
{
    public class CreateBookingCommand : IRequest<int>
    {
        public DateTime FromDateTime { get; set; }
        public DateTime ReturnDateTime { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public int PickUpLocationId { get; set; }
        public int DropOffLocationId { get; set; }
        public int PackageId { get; set; }
        
        

    }

    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateBookingCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateBookingCommand command, CancellationToken cancellationToken)
        {
            var entity = new Booking

            {
                FromDateTime = DateTime.Today,
                ReturnDateTime = DateTime.Today,
                // TODO: remove and use enumeration
                Status = "Cancelled",
                // TODO: removed and calculate based on package + car + ...
                Amount = 569.5,
                CustomerId = command.CustomerId,
                CarId = command.CarId,
                InvoiceId = null,
                PickUpLocationId = command.PickUpLocationId,
                DropOffLocationId = command.DropOffLocationId,
                PackageId = command.PackageId
            };

            _context.Bookings.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}