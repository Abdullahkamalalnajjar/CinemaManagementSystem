using CinemaManagementSystem.Core.Bases;
using CinemaManagementSystem.Core.Features.Authorization.Queries.Model;
using CinemaManagementSystem.Core.Resources;
using CinemaManagementSystem.Data.DTOs;
using CinemaManagementSystem.Data.Entities.Identity;
using CinemaManagementSystem.Service.Abstract;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Data.DTOs;

namespace SchoolProject.Core.Features.Authorization.Queries.Handler;

public class AuthorizationQueryHandler : ResponseHandler
    , IRequestHandler<GetUserRolesByIdQuery, Response<GetUserRolesResponse>>,
    IRequestHandler<GetUserClaimsByIdQuery, Response<GetUserClaimsResponse>>,
    IRequestHandler<GetRolesListQuery, Response<List<GetRolesResponse>>>,
    IRequestHandler<GetClaimsListQuery, Response<List<GetClaimsResponse>>>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IAuthorizationService _authorizationService;

    public AuthorizationQueryHandler(UserManager<AppUser> userManager, IAuthorizationService authorizationService, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _userManager = userManager;
        _authorizationService = authorizationService;
    }


    public async Task<Response<GetUserRolesResponse>> Handle(GetUserRolesByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);
        if (user == null) return NotFound<GetUserRolesResponse>();
        var roles = await _authorizationService.GetUserRolesDataAsync(user);
        var response = Success(roles);
        return response;
    }

    public async Task<Response<GetUserClaimsResponse>> Handle(GetUserClaimsByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);
        if (user == null) return NotFound<GetUserClaimsResponse>();
        var claims = await _authorizationService.GetUserClaimsDataAsync(user);
        var response = Success(claims);
        return response;
    }

    public async Task<Response<List<GetRolesResponse>>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
    {
        var roles = await _authorizationService.GetRolesListAsync();
        var response = Success(roles);
        return response;
    }

    public async Task<Response<List<GetClaimsResponse>>> Handle(GetClaimsListQuery request, CancellationToken cancellationToken)
    {
        var claims = _authorizationService.GetClaimsListAsync();
        var response = Success(claims);
        return response;
    }
}