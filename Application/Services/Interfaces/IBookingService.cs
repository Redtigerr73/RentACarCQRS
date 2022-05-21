
using Application.Bookings.Commands;
using Application.Bookings.Queries.GetBookings;
using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IBookingService
    {
        Task<BookingsVm> GetAllBookingsAsync(CancellationToken cancellationToken);
        Task<BookingDto> BookingDetailsAsync(int? id, CancellationToken cancellationToken);
        Task<BookingDto> CreateNewBookingAsync(CreateBookingCommand command, CancellationToken cancellationToken);
        Task<int> UpdateBookingAsync(UpdateBookingCommand command, CancellationToken cancellationToken);
        Task<BookingsVm> DisplayBookingAsync(int? id, CancellationToken cancellationToken);
        Task<BookingsVm> EditBookingAsync(int id, CreateBookingCommand command, CancellationToken cancellationToken);
        Task DeleteBookingAsync(int id, CancellationToken cancellationToken);
        bool BookingExists(int? id, CancellationToken cancellationToken);
        bool BookingIsCancelled(int? id, CancellationToken cancellationToken);
        bool BookingIsBilled(int? id, CancellationToken cancellationToken);
        bool BillIsAllowed(int? id, CancellationToken cancellationToken);
        bool BookingIsClosed(int? id, CancellationToken cancellationToken);
        

    }
}
