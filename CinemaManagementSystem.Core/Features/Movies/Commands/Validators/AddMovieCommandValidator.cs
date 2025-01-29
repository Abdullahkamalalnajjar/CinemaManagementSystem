using CinemaManagementSystem.Core.Features.Movies.Commands.Models;
using CinemaManagementSystem.Service.Abstract;
using FluentValidation;

namespace CinemaManagementSystem.Core.Features.Movies.Commands.Validators
{
    public class AddMovieCommandValidator : AbstractValidator<AddMovieCommand>
    {
        private readonly IMovieService _movieService;

        public AddMovieCommandValidator(IMovieService movieService)
        {
            _movieService = movieService;
            CustomAddMovieRules();
            ApplyAddMovieRules();
        }

        private void ApplyAddMovieRules()
        {
            RuleFor(x => x.Title).NotEmpty().NotNull()
                .WithMessage("Title is required");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Type is required");
            RuleFor(x => x.AgeRating)
                .NotEmpty().WithMessage("AgeRating is required");
            RuleFor(x => x.DurationMinutes)
                .NotEmpty().WithMessage("DurationMinutes is required");
            RuleFor(x => x.PosterUrl)
                .NotEmpty().WithMessage("PosterUrl is required");
            RuleFor(x => x.ReleaseDate)
                .NotEmpty().WithMessage("ReleaseDate is required");
        }

        private void CustomAddMovieRules()
        {

            RuleFor(x => x.Title).
                MustAsync(async (title, cancellation) =>
                {
                    return !await _movieService.IsMovieExist(title);

                }).WithMessage("Title already exists");

        }
    }
}
