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
    public class UpdateBookingCommand : IRequest
    {
            public int Id { get; set; }

            public string Name { get; set; }

            public bool IsPayed { get; set; }
        }

        public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateBookingCommand>
        {
            private readonly IApplicationDbContext _context;

            public UpdateTodoItemCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Bookings.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Booking), request.Id);
                }

                entity.Name = request.Name;
                entity.IsPayed = request.IsPayed;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
