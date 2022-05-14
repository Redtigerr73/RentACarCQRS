using Application.Common.CustomErrors;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Bookings.Commands
{
    public class UIDeleteBookingCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteBookingCommandHandler : IRequestHandler<UIDeleteBookingCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteBookingCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UIDeleteBookingCommand request, CancellationToken cancellationToken)
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