using AutoMapper;
using CinemaManagementSystem.Core.Bases;
using CinemaManagementSystem.Core.Features.Users.Command.Model;
using CinemaManagementSystem.Core.Resources;
using CinemaManagementSystem.Data.Entities.Identity;
using CinemaManagementSystem.Service.Abstract;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace CinemaManagementSystem.Core.Features.Users.Command.Handler;

public class AppUserHandler : ResponseHandler,
    IRequestHandler<AddUserCommand, Response<string>>,
    IRequestHandler<EditUserCommand, Response<string>>,
    IRequestHandler<DeleteUserCommand, Response<string>>,
    IRequestHandler<ChangeUserPasswordCommand, Response<string>>
{
    private readonly IStringLocalizer<SharedResources> _localizer;
    private readonly IMapper _mapper;
    private readonly IAppUserService _appUserService;
    private readonly UserManager<AppUser> _userManager;

    public AppUserHandler(IStringLocalizer<SharedResources> localizer, IMapper mapper, IAppUserService appUserService, UserManager<AppUser> userManager) : base(localizer)
    {
        _localizer = localizer;
        _mapper = mapper;
        _appUserService = appUserService;
        _userManager = userManager;
    }

    public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        #region commant
        //// check email exist or no
        //var checkEmailUser = await _userManager.FindByEmailAsync(request.Email);
        //if (checkEmailUser != null) return BadRequest<string>(_localizer[SharedResourcesKeys.Email] + ":" + _localizer[SharedResourcesKeys.IsExist]);
        //// check username exist or no
        //var checkUsername = await _userManager.FindByNameAsync(request.Username);
        //if (checkUsername != null) return BadRequest<string>(_localizer[SharedResourcesKeys.UserName] + ":" + _localizer[SharedResourcesKeys.IsExist]);
        //// Make Mapping
        //var user = _mapper.Map<AppUser>(request);
        //// Create user
        //var result = await _userManager.CreateAsync(user, request.Password);
        //if (!result.Succeeded)
        //{
        //    // Localize each error and return the first one
        //    var localizedErrors = result.Errors
        //        .Select(error => _localizer[$"{error.Code}"] ?? error.Description)
        //        .ToList();
        //    //   return BadRequest<string>(localizedErrors.FirstOrDefault()!);
        //    return BadRequest<string>(localizedErrors.FirstOrDefault()!);

        //}
        //return Created(_localizer[SharedResourcesKeys.SignUpSuccess].Value);
        #endregion


        var user = _mapper.Map<AppUser>(request);
        //Create
        var createResult = await _appUserService.AddUserAsync(user, request.Password);
        switch (createResult)
        {
            case "EmailIsExist": return BadRequest<string>(_localizer[SharedResourcesKeys.IsExist]);
            case "UserNameIsExist": return BadRequest<string>(_localizer[SharedResourcesKeys.IsExist]);
            case "ErrorInCreateUser": return BadRequest<string>("Error in CreateUser");
            case "Failed": return BadRequest<string>("");
            case "Success": return Success<string>("");
            default: return BadRequest<string>(createResult);
        }

    }

    public async Task<Response<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        // check id exist or no 
        var checkIdUser = await _userManager.FindByIdAsync(request.Id);
        if (checkIdUser == null) return NotFound<string>();
        //make mapping 
        var mappedUser = _mapper.Map<AppUser>(request);
        var result = await _userManager.UpdateAsync(mappedUser);
        if (result.Succeeded) return Updated(_localizer[SharedResourcesKeys.Updated].Value);
        return BadRequest<string>(result.Errors.FirstOrDefault()?.Description!);
    }

    public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        //check user is existed or no 
        var checkUser = await _userManager.Users.FirstOrDefaultAsync(i => i.Id.Equals(request.Id), cancellationToken: cancellationToken);
        if (checkUser == null) return NotFound<string>();
        await _userManager.DeleteAsync(checkUser);
        return Deleted<string>();
    }

    public async Task<Response<string>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
    {
        // find user first to check 
        var user = await _userManager.Users.FirstOrDefaultAsync(i => i.Id.Equals(request.Id), cancellationToken: cancellationToken);
        if (user == null) return NotFound<string>();
        var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
        return result.Succeeded ? Updated(_localizer[SharedResourcesKeys.ChangePasswordSuccess].Value) : BadRequest<string>(result.Errors.FirstOrDefault()?.Description!);
    }
}
