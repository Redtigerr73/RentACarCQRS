using Application.Common.Interfaces;
using FluentValidation;

namespace Application.Bookings.Commands
{
    public class UpdateBookingCommandValidator : AbstractValidator<UpdateBookingCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateBookingCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(b => b.Id)
            .NotNull().WithMessage("Booking Id is Required");
            RuleFor(b => b.PickUpLocationId)
            .NotNull().WithMessage("Pick-up location is Required");
            RuleFor(b => b.DropOffLocationId)
            .NotNull().WithMessage("Drop-off location is Required");
        }
    }
}