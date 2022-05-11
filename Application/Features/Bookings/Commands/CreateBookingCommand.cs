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
        public int Id { get; set; }
        public DateTime FromDateTime { get; set; }
        public DateTime ReturnDateTime { get; set; }
        public String status { get; set; }
        public float amount { get; private set; }



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
                FromDateTime = DateTime.Today /*"2022-04-20T00:00:00"*/,
                ReturnDateTime= DateTime.Today,
                Status= "Cancelled",
                Amount= 569.5,
                CustomerId= 61,
                CarId = 26,
                InvoiceId = null,
                PickUpLocationId = 1,
                DropOffLocationId = 1
            };

            _context.Bookings.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}