using Application.Common.Interfaces;
using Application.Services.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Bookings.Queries.GetBookings
{
    public class GetBookingsQuery : IRequest<BookingsVm>
    {
        
    }     

    public class GetbookingsQueryHandler : IRequestHandler<GetBookingsQuery, BookingsVm>
    {
        /*private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;*/
        public readonly IBookingService _bookingService;     
            
        

        public GetbookingsQueryHandler(IBookingService bookingService)
        {
            
            _bookingService = bookingService;
        }

        public Task<BookingsVm> Handle(GetBookingsQuery request, CancellationToken cancellationToken)
        {
            return _bookingService.GetAllBookingsAsync(cancellationToken);
           
        }

       
    }
}