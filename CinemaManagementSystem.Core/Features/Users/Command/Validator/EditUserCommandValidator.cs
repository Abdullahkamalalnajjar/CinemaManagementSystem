using CinemaManagementSystem.Core.Features.Users.Command.Model;
using CinemaManagementSystem.Core.Resources;
using CinemaManagementSystem.Service.Abstract;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace CinemaManagementSystem.Core.Features.Users.Command.Validator;

public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
{
    private readonly IAppUserService _appUserService;
    private readonly IStringLocalizer<SharedResources> _localizer;

    public EditUserCommandValidator(IAppUserService appUserService, IStringLocalizer<SharedResources> localizer)
    {
        _appUserService = appUserService;
        _localizer = localizer;
    }

    public void EditUserValidator()
    {
        RuleFor(e => e.Email).MustAsync(async (model, Key, CancellationToken) =>
            !await _appUserService.IsEmailExistExcludeSelf(model.Id, model.Email)).WithMessage(_localizer[SharedResourcesKeys.IsExist]);
    }
}