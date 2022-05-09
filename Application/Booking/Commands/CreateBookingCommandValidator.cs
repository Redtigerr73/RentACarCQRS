using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Booking.Commands
{
    public class CreateBookingCommandValidator: AbstractValidator<CreateBookingCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateBookingCommandValidator (IApplicationDbContext context)
        {
            _context = context;
            RuleFor(n => n.Name)
                .NotEmpty().WithMessage("Name of reservation is required.")
                .MaximumLength(200).WithMessage("Name of reservation cannot exceed 200 characters")
                .MustAsync(BeUniqueName).WithMessage("The specified title already exists.");

        }

        public async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            return await _context.Bookings
                .AllAsync(n => n.Name != name);
        }


    }
}
