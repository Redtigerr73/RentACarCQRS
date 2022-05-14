using Application.Bookings.Commands;
using FluentValidation;

namespace Application.Features.Bookings.Commands
{
    public class UIUpdateBookingCommandValidator : AbstractValidator<UIUpdateBookingCommand>
    {
        public UIUpdateBookingCommandValidator()
        {
            RuleFor(v => v.Name)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}