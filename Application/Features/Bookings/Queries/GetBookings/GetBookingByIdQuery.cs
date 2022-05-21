using Application.Bookings.Queries.GetBookings;
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
    public record GetBookingByIdQuery(int id) : IRequest<BookingDto>
    {
        
    }

        public class GetBookingByIdQueryHandler : IRequestHandler<GetBookingByIdQuery, BookingDto>
        {

            public readonly IBookingService _bookingService;


            public GetBookingByIdQueryHandler(IBookingService bookingService)
            {

                _bookingService = bookingService;
            }

            public Task<BookingDto> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
            {
                return _bookingService.BookingDetailsAsync(request.id, cancellationToken);

            }


        }
    }

