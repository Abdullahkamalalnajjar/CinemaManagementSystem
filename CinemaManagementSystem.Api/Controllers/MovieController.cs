using CinemaManagementSystem.Api.Base;
using CinemaManagementSystem.Core.Features.Movies.Commands.Models;
using CinemaManagementSystem.Core.Features.Movies.Queries.Models;
using CinemaManagementSystem.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace CinemaManagementSystem.Api.Controllers
{

    public class MovieController : AppBaseController
    {
        [HttpPost(Router.MovieRouting.Create)]
        public async Task<IActionResult> CreateMovie([FromBody] AddMovieCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut(Router.MovieRouting.Edit)]
        public async Task<IActionResult> EditMovie([FromBody] EditMovieCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpGet(Router.MovieRouting.List)]
        public async Task<IActionResult> GetMovieList()
        {
            var request = new GetMovieListQuery();
            var response = await Mediator.Send(request);
            return NewResult(response);
        }
        [HttpGet(Router.MovieRouting.Paginated)]
        public async Task<IActionResult> GetMoviePaginatedList([FromQuery] GetMoviePaginatedListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet(Router.MovieRouting.GetById)]
        public async Task<IActionResult> GetMovieById([FromRoute] int id)
        {
            var request = new GetMovieByIdQuery(id);
            var response = await Mediator.Send(request);
            return NewResult(response);
        }
        [HttpDelete(Router.MovieRouting.Delete)]
        public async Task<IActionResult> DeleteMovieById([FromRoute] int id)
        {
            var request = new DeleteMovieCommand(id);
            var response = await Mediator.Send(request);
            return NewResult(response);
        }
    }
}
