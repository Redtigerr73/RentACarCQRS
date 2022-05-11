using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Bookings.Queries.GetBookings
{
    public class GetBookingsQuery : IRequest<BookingsVm>
    { }

    public class GetbookingsQueryHandler : IRequestHandler<GetBookingsQuery, BookingsVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetbookingsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookingsVm> Handle(GetBookingsQuery request, CancellationToken cancellationToken)
        {
            return new BookingsVm
            {
                Bookings = await _context.Bookings
                .ProjectTo<BookingDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Name)
                .ToListAsync(cancellationToken)
            };
        }
    }
}