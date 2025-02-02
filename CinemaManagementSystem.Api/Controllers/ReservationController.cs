using CinemaManagementSystem.Api.Base;
using CinemaManagementSystem.Core.Features.ReservationsShowtime.Commands.Models;
using CinemaManagementSystem.Core.Features.ReservationsShowtime.Queries.Models;
using CinemaManagementSystem.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace CinemaManagementSystem.Api.Controllers
{

    public class ReservationController : AppBaseController
    {
        [HttpPost(Router.ReservationRouting.Create)]
        public async Task<IActionResult> CreateReservation([FromBody] CreateReservationCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }


        [HttpDelete(Router.ReservationRouting.Delete)]
        public async Task<IActionResult> DeleteReservation([FromRoute] int id)
        {
            var request = new DeleteReservationCommand(id);
            var response = await Mediator.Send(request);
            return NewResult(response);
        }

        [HttpPut(Router.ReservationRouting.Edit)]

        public async Task<IActionResult> EditReservation([FromBody] EditReservationCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpGet(Router.ReservationRouting.List)]
        public async Task<IActionResult> GetReservationsList()
        {
            var request = new GetReservationListQuery();
            var response = await Mediator.Send(request);
            return NewResult(response);
        }

    }
}
