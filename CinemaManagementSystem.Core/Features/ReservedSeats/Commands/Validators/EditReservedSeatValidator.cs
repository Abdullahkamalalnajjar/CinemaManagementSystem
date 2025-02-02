using CinemaManagementSystem.Core.Features.ReservedSeats.Commands.Models;
using CinemaManagementSystem.Service.Abstract;
using FluentValidation;

namespace CinemaManagementSystem.Core.Features.ReservedSeats.Commands.Validators
{
    public class EditReservedSeatValidator : AbstractValidator<EditReservedSeatCommand>
    {
        private readonly IReservedSeatService _reservedSeatService;

        public EditReservedSeatValidator(IReservedSeatService reservedSeatService)
        {
            _reservedSeatService = reservedSeatService;

            ApplyEditValidator();
            ApplyCustomRules();
        }

        public void ApplyEditValidator()
        {

            RuleFor(x => x.Id)
                 .NotEmpty().WithMessage("Id is required")
                 .GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(x => x.ReservationId)
                   .NotEmpty().WithMessage("ReservationId is required")
                   .GreaterThan(0).WithMessage("ReservationId must be greater than 0");
            RuleFor(x => x.SeatNumber)
                .NotEmpty().WithMessage("SeatNumber is required");
        }
        public void ApplyCustomRules()
        {
            RuleFor(x => x.Id)
                .MustAsync(async (id, cancellation) =>
                await _reservedSeatService.GetReservedSeatByIdAsync(id) is not null)
                .WithMessage("ReservedSeat is not found");
        }
    }
}
