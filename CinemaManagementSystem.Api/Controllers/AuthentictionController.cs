using CinemaManagementSystem.Api.Base;
using CinemaManagementSystem.Core.Features.Authentication.Model;
using CinemaManagementSystem.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace CinemaManagementSystem.Api.Controllers;

public class AuthenticationController : AppBaseController
{

    [HttpPost(Router.AuthenticationRouting.SginIn)]
    public async Task<IActionResult> SignIn([FromBody] SignInCommand command)
    {
        var response = await Mediator.Send(command);
        return Ok(response);
    }

}