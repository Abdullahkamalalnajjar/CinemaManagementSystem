using CinemaManagementSystem.Core.Features.ReservationsShowtime.Commands.Models;
using CinemaManagementSystem.Data.Entities.Identity;
using CinemaManagementSystem.Service.Abstract;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace CinemaManagementSystem.Core.Features.ReservationsShowtime.Commands.Validators
{
    public class EditReservationCommandValidator : AbstractValidator<EditReservationCommand>
    {
        private readonly IShowtimeService _showtimeService;
        private readonly IReservationService _reservationService;
        private readonly UserManager<AppUser> _userManager;

        public EditReservationCommandValidator(IShowtimeService showtimeService, IReservationService reservationService, UserManager<AppUser> userManager)
        {
            _showtimeService = showtimeService;
            _reservationService = reservationService;
            _userManager = userManager;
            ApplyEditReservationCommandValidator();
            CustomValidation();
        }
        public void ApplyEditReservationCommandValidator()
        {
            RuleFor(x => x.ShowtimeId).NotEmpty().WithMessage("ShowtimeId is Required");
            RuleFor(x => x.AppUserId).NotEmpty().WithMessage("AppUserId is Required");
            RuleFor(x => x.SeatPrice).GreaterThan(0).WithMessage("SeatPrice is Required"); ;
            RuleFor(x => x.NumberOfSeats).LessThan(101).WithMessage("NumberOfSeats is Required");
        }

        public void CustomValidation()
        {

            RuleFor(x => x.Id).MustAsync(async (Id, cancellation) =>
            {
                return await _reservationService.GetReservationByIdAsync(Id) != null;
            }).WithMessage("ReservationId  is Not Exist");

            RuleFor(x => x.ShowtimeId).MustAsync(async (showtimeId, cancellation) =>
            {
                return await _showtimeService.GetShowtimeByIdAsync(showtimeId) != null;
            }).WithMessage("ShowtimeId is not valid");

            RuleFor(x => x.AppUserId).MustAsync(async (appUserId, cancellation) =>
            {
                return await _userManager.FindByIdAsync(appUserId) != null;
            }).WithMessage("AppUserId is not valid");
        }
    }
}
