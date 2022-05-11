using Application.Common.CustomErrors;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Bookings.Commands
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

            //entity.Name = request.Name;
            //entity.IsPayed = request.IsPayed;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}