using CinemaManagementSystem.Core.Features.Showtimes.Commands.Models;
using CinemaManagementSystem.Service.Abstract;
using FluentValidation;

namespace CinemaManagementSystem.Core.Features.Showtimes.Commands.Validators
{
    public class EditShowtimeCommandValidator : AbstractValidator<EditShowtimeCommand>
    {
        private readonly IShowtimeService _showtimeService;
        private readonly IMovieService _movieService;
        private readonly ITheaterService _theaterService;

        public EditShowtimeCommandValidator(IShowtimeService showtimeService, IMovieService movieService, ITheaterService theaterService)
        {
            _showtimeService = showtimeService;
            _movieService = movieService;
            _theaterService = theaterService;
            ApplyEditShowtimeCommandValidator();
            CustomEditShowtimeCommand();
        }

        public void ApplyEditShowtimeCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("This Field is required");
            RuleFor(x => x.MovieId).NotEmpty().WithMessage("This Field is required"); ;
            RuleFor(x => x.TheaterId).NotEmpty().WithMessage("This Field is required"); ;
            RuleFor(x => x.StartTime).NotEmpty().WithMessage("This Field is required"); ;
            RuleFor(x => x.SeatPrice).NotEmpty().WithMessage("This Field is required"); ;
            RuleFor(x => x.AvailableSeats).NotEmpty().WithMessage("This Field is required"); ;
        }

        public void CustomEditShowtimeCommand()
        {
            RuleFor(x => x.AvailableSeats).GreaterThan(0).WithMessage("Available Seats must be greater than 0");
            RuleFor(x => x.SeatPrice).GreaterThan(0).WithMessage("Seat Price must be greater than 0");
            RuleFor(x => x.Id)
                .MustAsync(async (key, CancellationToken) => await _showtimeService.GetShowtimeByIdForValidatorAsync(key))
                .WithMessage("Showtime Not Found To Edit it ");
            RuleFor(x => x.TheaterId)
            .MustAsync(async (key, CancellationToken) => await _theaterService.IsTheaterByIdExist(key))
            .WithMessage("Theater Not Found");

            RuleFor(x => x.MovieId)
        .MustAsync(async (key, CancellationToken) => await _movieService.IsMovieByIdExist(key))
        .WithMessage("Movie Not Found");
        }
    }
}
