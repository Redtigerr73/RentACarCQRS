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
    public class UIGetBookingsQuery : IRequest<UIBookingsVm>
    { }

    public class GetbookingsQueryHandler : IRequestHandler<UIGetBookingsQuery, UIBookingsVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetbookingsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UIBookingsVm> Handle(UIGetBookingsQuery request, CancellationToken cancellationToken)
        {
            return new UIBookingsVm
            {
                Bookings = await _context.Bookings
                .ProjectTo<UIBookingDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Name)
                .ToListAsync(cancellationToken)
            };
        }
    }
}