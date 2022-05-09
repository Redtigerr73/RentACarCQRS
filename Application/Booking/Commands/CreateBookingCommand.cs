using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Booking.Commands
{
    public class CreateBookingCommand: IRequest<int>
    {
        public string Name { get; set; }  
    }

    public class CreateBookingCommandHandler: IRequestHandler<CreateBookingCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateBookingCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateBookingCommand command, CancellationToken cancellationToken)
        {
            var entity = new BookingEntity
            {
                Name = command.Name,
                Note = "Note Not Found"
            };

            _context.Bookings.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
