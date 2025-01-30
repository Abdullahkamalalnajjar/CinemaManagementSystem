using CinemaManagementSystem.Api.Base;
using CinemaManagementSystem.Core.Features.Theaters.Commands.Models;
using CinemaManagementSystem.Core.Features.Theaters.Queries.Models;
using CinemaManagementSystem.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace CinemaManagementSystem.Api.Controllers
{

    public class TheaterController : AppBaseController
    {


        [HttpPost(Router.TheaterRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddTheaterCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut(Router.TheaterRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditTheaterCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpGet(Router.TheaterRouting.List)]
        public async Task<IActionResult> GetTheaterList()
        {
            var request = new GetTheaterListQuery();
            var response = await Mediator.Send(request);
            return Ok(response);
        }


    }
}
