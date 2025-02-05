using CinemaManagementSystem.Core.Bases;
using CinemaManagementSystem.Core.Features.Authentication.Commands.Model;
using CinemaManagementSystem.Core.Resources;
using CinemaManagementSystem.Data.Entities.Identity;
using CinemaManagementSystem.Data.Helpers;
using CinemaManagementSystem.Service.Abstract;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;

namespace CinemaManagementSystem.Core.Features.Authentication.Commands.Handler;

public class AuthenticationCommandHandler : ResponseHandler, IRequestHandler<SignInCommand, Response<JwtAuthResult>>
{
    private readonly IAuthenticationService _authenticationService;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;
    private readonly IStringLocalizer<SharedResources> _localizer;

    public AuthenticationCommandHandler(IAuthenticationService authenticationService, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _authenticationService = authenticationService;
        _signInManager = signInManager;
        _userManager = userManager;
        _localizer = localizer;
    }

    public async Task<Response<JwtAuthResult>> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        // checkuser existing or no 
        var user = await _userManager.FindByNameAsync(request.Username);
        if (user == null) return NotFound<JwtAuthResult>();
        // try to signin
        var signinResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
        if (!signinResult.Succeeded) return BadRequest<JwtAuthResult>(_localizer[SharedResourcesKeys.PasswordInCorrect]);
        // Get accessToken
        var accessToken = await _authenticationService.GenerateTokenAsync(user);
        return Success(accessToken);
    }

}