﻿using Application.Bookings.Commands;
using Application.Bookings.Queries.GetBookings;
using Application.Common.CustomErrors;
using Application.Common.Interfaces;
using Application.Services.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
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



        public async Task<BookingsVm> BookingDetailsAsync(int? id, CancellationToken cancellationToken)
        {
            var allBookings = await _context.Bookings
            
            .ToListAsync(cancellationToken);

            var bookingById = allBookings.FirstOrDefault(b => b.Id == id);
            return _mapper.Map<BookingsVm>(bookingById);
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

        public Task<BookingsVm> DisplayBookingAsync(int? id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<BookingsVm> EditBookingAsync(int id, CreateBookingCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<BookingsVm> CancelBookingAsync(int? id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task AfterCancelBookingAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
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
    }
}
