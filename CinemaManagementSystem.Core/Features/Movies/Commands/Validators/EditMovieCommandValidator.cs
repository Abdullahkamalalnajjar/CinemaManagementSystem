using CinemaManagementSystem.Core.Features.Movies.Commands.Models;
using CinemaManagementSystem.Core.Resources;
using CinemaManagementSystem.Service.Abstract;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace CinemaManagementSystem.Core.Features.Movies.Commands.Validators
{
    public class EditMovieCommandValidator : AbstractValidator<EditMovieCommand>
    {
        private readonly IMovieService _movieService;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public EditMovieCommandValidator(IMovieService movieService, IStringLocalizer<SharedResources> localizer)
        {
            _movieService = movieService;
            _localizer = localizer;
            ApplyMovieCommandValidator();
        }

        public void ApplyMovieCommandValidator()
        {

            RuleFor(x => x.Title).
                MustAsync(async (model, key, CancellationToken) => !await _movieService.IsTitleExistExcludeSelf(model.Id, key))
                .WithMessage(_localizer[SharedResourcesKeys.TitleIsExist]);
        }
    }
}
