using Application.Common.Interfaces;
using Application.CustomErrors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Booking.Commands
{
    public class DeleteBookingCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteBookingCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Bookings.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Booking), request.Id);
            }

            _context.Bookings.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}

