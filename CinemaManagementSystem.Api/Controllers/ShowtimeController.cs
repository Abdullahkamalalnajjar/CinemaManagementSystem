﻿using CinemaManagementSystem.Api.Base;
using CinemaManagementSystem.Core.Features.Showtimes.Commands.Models;
using CinemaManagementSystem.Core.Features.Showtimes.Queries.Models;
using CinemaManagementSystem.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace CinemaManagementSystem.Api.Controllers
{

    public class ShowtimeController : AppBaseController
    {
        [HttpPost(Router.ShowtimeRouting.Create)]
        public async Task<IActionResult> CreateShowtime([FromBody] AddShowtimeCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpGet(Router.ShowtimeRouting.GetById)]
        public async Task<IActionResult> GetShowtimeById([FromRoute] int id)
        {
            var request = new GetShowtimeByIdQuery(id);
            var response = await Mediator.Send(request);
            return NewResult(response);
        }
    }
}
