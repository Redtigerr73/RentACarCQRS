using Application.Common.Interfaces;
using Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Bookings.Commands
{
    public class CreateBookingCommandValidator : AbstractValidator<Booking>
    {
        private readonly IApplicationDbContext _context;

        public CreateBookingCommandValidator(IApplicationDbContext context)
        {
            _context = context;
            /*RuleFor(b => b.Customer.LastName)
            .NotNull().WithMessage("Required");

            RuleFor(b => b.FromDateTime)
            .NotNull().WithMessage("Required")
            .GreaterThan(DateTime.Now.ToLocalTime()).WithMessage("Date is invalid");

            RuleFor(b => b.ReturnDateTime)
            .NotNull().WithMessage("Required")
            .GreaterThan(b => b.FromDateTime).WithMessage("Return date must be after pick up date");

            RuleFor(b => b.CustomerId)
            .NotNull().WithMessage("Required");

            RuleFor(b => b.PickUpLocationId)
            .NotNull().WithMessage("Required")
            .When(b => b.PickUpLocationId != b.Car.LocationId).WithMessage("Mismatch with current car's location");

            RuleFor(b => b.DropOffLocationId)
            .NotNull().WithMessage("Required");

            RuleFor(b => b.Car.Mileage)
            .NotNull().WithMessage("Required");*/
        }


    }
}