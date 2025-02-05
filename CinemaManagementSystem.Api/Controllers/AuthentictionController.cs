using CinemaManagementSystem.Api.Base;
using CinemaManagementSystem.Core.Features.Authentication.Commands.Model;
using CinemaManagementSystem.Core.Features.Authentication.Queries.Models;
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

    [HttpGet(Router.AuthenticationRouting.ConfirmEmail)]
    public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailQuery query)
    {
        var response = await Mediator.Send(query);
        return NewResult(response);
    }
}