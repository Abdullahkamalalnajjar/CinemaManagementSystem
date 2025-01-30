using CinemaManagementSystem.Core.Features.Showtimes.Commands.Models;
using CinemaManagementSystem.Service.Abstract;
using FluentValidation;

namespace CinemaManagementSystem.Core.Features.Showtimes.Commands.Validators
{
    public class AddShowtimeCommandValidator : AbstractValidator<AddShowtimeCommand>
    {
        private readonly IMovieService _movieService;
        private readonly ITheaterService _theaterService;

        public AddShowtimeCommandValidator(IMovieService movieService, ITheaterService theaterService)
        {
            _movieService = movieService;
            _theaterService = theaterService;
            ApplyAddShowtimeCommandValidator();
            CustomAddShowtimeCommandValidator();
        }

        public void ApplyAddShowtimeCommandValidator()
        {
            RuleFor(x => x.MovieId).NotEmpty().WithMessage("Moive Id is Required");
            RuleFor(x => x.TheaterId).NotEmpty().WithMessage("Theater Id is Required");
            RuleFor(x => x.StartTime).NotEmpty().WithMessage("StartTime is Required");
            RuleFor(x => x.SeatPrice).NotEmpty().WithMessage("SeatPrice is Required");
            RuleFor(x => x.AvailableSeats).NotEmpty().WithMessage("AvailbleSeats is Required");
        }

        public void CustomAddShowtimeCommandValidator()
        {

            RuleFor(x => x.MovieId)
                .MustAsync(async (key, CancellationToken) => await _movieService.IsMovieByIdExist(key))
                .WithMessage("Movie Id is not Exist");

            RuleFor(x => x.TheaterId)
             .MustAsync(async (key, CancellationToken) => await _theaterService.IsTheaterByIdExist(key))
             .WithMessage("Theater Id is not Exist");

        }
    }
}
