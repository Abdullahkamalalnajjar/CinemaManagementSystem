using CinemaManagementSystem.Core.Features.ReservedSeats.Commands.Models;
using FluentValidation;

namespace CinemaManagementSystem.Core.Features.ReservedSeats.Commands.Validators
{
    public class CreateReservedSeatValidator : AbstractValidator<CreateReservedSeatCommand>
    {
        public CreateReservedSeatValidator()
        {

            RuleFor(x => x.ReservationId)
                .NotEmpty().WithMessage("ReservationId is required")
                .GreaterThan(0).WithMessage("ReservationId must be greater than 0");
            RuleFor(x => x.SeatNumber)
                .NotEmpty().WithMessage("SeatNumber is required")
                .MaximumLength(10).WithMessage("SeatNumber must not exceed 10 characters");

        }
    }
}
