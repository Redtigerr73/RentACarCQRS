using Application.Bookings.Queries.GetBookings;
using Application.Common.Models;
using Application.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Bookings.Queries.GetBookings
{
    public class GetPaginatedBookingsQuery : IRequest<Pagination<BookingDto>>
    {
        public int pageNumber { get; set; } = 1;
        public int pageSize { get; set; } = 10;
    }

    public class GetPaginatedBookingsQueryHandler : IRequestHandler<GetPaginatedBookingsQuery,Pagination<BookingDto>>
    {

        public readonly IBookingService _bookingService;


        public GetPaginatedBookingsQueryHandler(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public async Task<Pagination<BookingDto>> Handle(GetPaginatedBookingsQuery request, CancellationToken cancellationToken)
        {
            return await _bookingService.GetAllBookingsWithPagination(request.pageNumber, request.pageSize, cancellationToken);
        }
    }
}
