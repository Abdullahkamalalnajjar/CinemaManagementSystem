using CinemaManagementSystem.Data.Entities.Identity;
using CinemaManagementSystem.Infrustructure.DbContext;
using CinemaManagementSystem.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagementSystem.Service.Implementation;

public class AppUserService : IAppUserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly IEmailService _emailService;
    private readonly IUrlHelper _urlHelper;

    public AppUserService(UserManager<AppUser> userManager,
                                      IHttpContextAccessor httpContextAccessor,
                                      IEmailService emailService,
                                      ApplicationDbContext applicationDBContext,
                                      IUrlHelper urlHelper)
    {
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
        _applicationDbContext = applicationDBContext;
        _emailService = emailService;
        _urlHelper = urlHelper;
    }

    public async Task<string> AddUserAsync(AppUser user, string password)
    {
        var trans = await _applicationDbContext.Database.BeginTransactionAsync();
        try
        {
            //if Email is Exist
            var existUser = await _userManager.FindByEmailAsync(user.Email);
            //email is Exist
            if (existUser != null) return "EmailIsExist";

            //if username is Exist
            var userByUserName = await _userManager.FindByNameAsync(user.UserName);
            //username is Exist
            if (userByUserName != null) return "UserNameIsExist";
            //Create
            var createResult = await _userManager.CreateAsync(user, password);
            //Failed
            if (!createResult.Succeeded)
                return string.Join(",", createResult.Errors.Select(x => x.Description).ToList());

            await _userManager.AddToRoleAsync(user, "User");

            //Send Confirm Email
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var resquestAccessor = _httpContextAccessor.HttpContext.Request;
            var returnUrl = resquestAccessor.Scheme + "://" + resquestAccessor.Host + _urlHelper.Action("ConfirmEmail", "Authentication", new { userId = user.Id, code = code });
            var message = $"To Confirm Email Click Link: <a href='{returnUrl}'>Link Of Confirmation</a>";
            //$"/Api/V1/Authentication/ConfirmEmail?userId={user.Id}&code={code}";
            //message or body
            await _emailService.SendEmailAsync(user.Email, message, "ConFirm Email");

            await trans.CommitAsync();
            return "Success";
        }
        catch (Exception ex)
        {
            await trans.RollbackAsync();
            return "Failed";
        }

    }

    public async Task<bool> IsEmailExistExcludeSelf(string id, string email)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == email & u.Id != id);
        return user != null;
    }
}