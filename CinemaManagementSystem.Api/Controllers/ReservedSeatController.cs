using CinemaManagementSystem.Api.Base;
using CinemaManagementSystem.Core.Features.ReservedSeats.Commands.Models;
using CinemaManagementSystem.Core.Features.ReservedSeats.Queries.Models;
using CinemaManagementSystem.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace CinemaManagementSystem.Api.Controllers
{

    public class ReservedSeatController : AppBaseController
    {

        [HttpPost(Router.ReservedSeatRouting.Create)]
        public async Task<IActionResult> Create(CreateReservedSeatCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete(Router.ReservedSeatRouting.Delete)]
        public async Task<IActionResult> DeleteReservedSeat([FromRoute] int id)
        {
            var request = new DeleteReservedSeatCommand(id);
            var response = await Mediator.Send(request);
            return NewResult(response);
        }

        [HttpPut(Router.ReservedSeatRouting.Edit)]

        public async Task<IActionResult> EditReservedSeats([FromBody] EditReservedSeatCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpGet(Router.ReservedSeatRouting.List)]
        public async Task<IActionResult> List()
        {
            var response = await Mediator.Send(new GetReservedSeatListQuery());
            return NewResult(response);
        }
    }
}
