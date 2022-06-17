using Application.Common.Interfaces;
using Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Bookings.Commands
{
    public class CreateBookingCommandValidator : AbstractValidator<CreateBookingCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateBookingCommandValidator(IApplicationDbContext context)
        {
            _context = context;
            RuleFor(b => b.FromDateTime)
            .NotNull()
            .NotEmpty().WithMessage("Required")
            .LessThan(DateTime.Now.ToLocalTime()).WithMessage("Booking can't start in the past");

            RuleFor(b => b.ReturnDateTime)
            .NotNull()
            .NotEmpty().WithMessage("Required")
            .GreaterThan(b => b.FromDateTime).WithMessage("Return date must be after pick up date");

            RuleFor(b => b.CarId)
            .NotNull()
            .NotEmpty().WithMessage("Car Id is Required");

            RuleFor(b => b.CustomerId)
            .NotNull()
            .NotEmpty().WithMessage("Customer Id is Required");


            RuleFor(b => b.DropOffLocationId)
            .NotNull()
            .NotEmpty().WithMessage("Drop-off location is Required");

            RuleFor(b => b.PackageId)
            .NotNull()
            .NotEmpty().WithMessage("Package Id is Required");
        }


    }
}