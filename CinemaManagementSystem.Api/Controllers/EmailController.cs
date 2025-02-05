using CinemaManagementSystem.Api.Base;
using CinemaManagementSystem.Core.Features.Emails.Commands.Models;
using CinemaManagementSystem.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace CinemaManagementSystem.Api.Controllers
{

    public class EmailController : AppBaseController
    {
        [HttpPost(Router.EmailRouting.SendEmail)]
        public async Task<IActionResult> SendEmail([FromQuery] SendEmailCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
