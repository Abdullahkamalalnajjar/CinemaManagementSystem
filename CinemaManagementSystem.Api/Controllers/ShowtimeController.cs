using CinemaManagementSystem.Api.Base;
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
        [HttpPut(Router.ShowtimeRouting.Edit)]

        public async Task<IActionResult> EditShowtime([FromBody] EditShowtimeCommand command)
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
        [HttpGet(Router.ShowtimeRouting.List)]
        public async Task<IActionResult> GetShowtimeList()
        {
            var request = new GetShowtimeListQuery();
            var response = await Mediator.Send(request);
            return NewResult(response);
        }
        [HttpGet(Router.ShowtimeRouting.Paginated)]
        public async Task<IActionResult> GetShowtimePaginatedList([FromQuery] GetShowtimePaginatedListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpDelete(Router.ShowtimeRouting.Delete)]
        public async Task<IActionResult> DeleteShowtimeById([FromRoute] int id)
        {
            var request = new DeleteShowtimeCommand(id);
            var response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}
