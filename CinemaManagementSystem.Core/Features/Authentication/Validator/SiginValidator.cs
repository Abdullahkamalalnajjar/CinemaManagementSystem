using CinemaManagementSystem.Core.Features.Authentication.Model;
using CinemaManagementSystem.Core.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace CinemaManagementSystem.Core.Features.Authentication.Validator;

public class SiginValidator : AbstractValidator<SignInCommand>
{
    private readonly IStringLocalizer<SharedResources> _localizer;

    public SiginValidator(IStringLocalizer<SharedResources> localizer)
    {
        _localizer = localizer;
    }

    public void AddSigninValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty].Value)
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotNull]);
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty].Value)
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotNull]);
    }
}