using AutoMapper;
using CinemaManagementSystem.Core.Bases;
using CinemaManagementSystem.Core.Features.Users.Queries.Model;
using CinemaManagementSystem.Core.Features.Users.Queries.Response;
using CinemaManagementSystem.Core.Resources;
using CinemaManagementSystem.Core.Wrappers;
using CinemaManagementSystem.Data.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;

namespace CinemaManagementSystem.Core.Features.Users.Queries.Handler;

public class AppUserQueryHandler : ResponseHandler,
    IRequestHandler<GetUserPaginatedListQuery, PaginatedResult<GetUserPaginatedListResponse>>,
    IRequestHandler<GetUserByIdQuery, Response<GetUserByIdResponse>>
{
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _userManager;

    public AppUserQueryHandler(IMapper mapper, UserManager<AppUser> userManager, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<PaginatedResult<GetUserPaginatedListResponse>> Handle(GetUserPaginatedListQuery request, CancellationToken cancellationToken)
    {
        var users = _userManager.Users.AsQueryable();
        var paginatedList = await _mapper.ProjectTo<GetUserPaginatedListResponse>(users)
            .ToPaginatedListAsync(request.PageNumber, request.PageSize);
        return paginatedList;
    }

    public async Task<Response<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        //check user exist or no 
        var user = await _userManager.FindByIdAsync(request.UserId);
        if (user is null) return NotFound<GetUserByIdResponse>();
        //make mapping
        var userMapper = _mapper.Map<GetUserByIdResponse>(user);
        return Success(userMapper);
    }
}