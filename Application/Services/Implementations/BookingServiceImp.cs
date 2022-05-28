using Application.Bookings.Commands;
using Application.Bookings.Queries.GetBookings;
using Application.Common.CustomErrors;
using Application.Common.Extensions;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Services.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Implementations
{
    public class BookingServiceImp : IBookingService
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BookingServiceImp(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookingsVm> GetAllBookingsAsync(CancellationToken cancellationToken)
        {

            return new BookingsVm
            {
             Bookings = await _context.Bookings
            .ProjectTo<BookingDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken)

            };
        }



        public async Task<BookingDto> BookingDetailsAsync(int? id, CancellationToken cancellationToken)
        {
            var allBookings = await _context.Bookings
            
            .ToListAsync(cancellationToken);

            var bookingById = allBookings.FirstOrDefault(b => b.Id == id);
            return _mapper.Map<BookingDto>(bookingById);
        }

        public async Task<BookingDto> CreateNewBookingAsync(CreateBookingCommand command, CancellationToken cancellationToken)
        {
            var entity = new Booking

            {
                FromDateTime = command.FromDateTime,
                ReturnDateTime = command.ReturnDateTime,
                // TODO: remove and use enumeration
                Status = "Cancelled",
                // TODO: removed and calculate based on package + car + ...
                Amount = 569.5,
                CustomerId = command.CustomerId,
                CarId = command.CarId,
                InvoiceId = null,
                PickUpLocationId = command.PickUpLocationId,
                DropOffLocationId = command.DropOffLocationId,
                PackageId = command.PackageId
            };
            try
            {
                await _context.Bookings.AddAsync(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return _mapper.Map<BookingDto>(entity);
            }catch (Exception ex)
            {
                throw new ValidationException();
            }
            
        }
        //TODO: Map correct attributes to update
        public async Task<int> UpdateBookingAsync(UpdateBookingCommand command, CancellationToken cancellationToken)
        {
            var booking = await _context.Bookings.FindAsync(command.Id);

            if (booking == null) throw new Exception();

            booking.DropOffLocationId = command.DropOffLocationId;
            booking.PickUpLocationId = command.PickUpLocationId;
             _context.Bookings.Update(booking);

            await _context.SaveChangesAsync(cancellationToken);
            return booking.Id;
            
        }

        public Task<BookingsVm> DisplayBookingAsync(int? id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<BookingsVm> EditBookingAsync(int id, CreateBookingCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteBookingAsync(int id, CancellationToken cancellationToken)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null) throw new NotFoundException(nameof(Booking), id);

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public bool BookingExists(int? id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public bool BookingIsCancelled(int? id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public bool BookingIsBilled(int? id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public bool BillIsAllowed(int? id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public bool BookingIsClosed(int? id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Pagination<BookingDto>> GetAllBookingsWithPagination(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var paginatedList = await _context.Bookings
                  .ProjectTo<BookingDto>(_mapper.ConfigurationProvider)
                  .PaginationAsync(pageNumber, pageSize);

            return paginatedList;   
        }
    }
}

