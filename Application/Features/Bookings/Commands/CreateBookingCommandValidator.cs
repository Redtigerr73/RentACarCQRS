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
            RuleFor(b => b.FromDateTime)
            .NotNull().WithMessage("Required")
            .LessThan(DateTime.Now.ToLocalTime()).WithMessage("Booking can't start in the past");

            RuleFor(b => b.ReturnDateTime)
            .NotNull().WithMessage("Required")
            .GreaterThan(b => b.FromDateTime).WithMessage("Return date must be after pick up date");

            RuleFor(b => b.CarId)
            .NotNull().WithMessage("Car Id is Required");

            RuleFor(b => b.CustomerId)
            .NotNull().WithMessage("Customer Id is Required");

            RuleFor(b => b.PickUpLocationId)
            .NotNull().WithMessage("Pick-up location is Required")
            .When(b => b.PickUpLocationId != b.Car.LocationId).WithMessage("Mismatch with current car's location");

            RuleFor(b => b.DropOffLocationId)
            .NotNull().WithMessage("Drop-off location is Required");

            RuleFor(b => b.PackageId)
            .NotNull().WithMessage("Package Id is Required");
        }


    }
}