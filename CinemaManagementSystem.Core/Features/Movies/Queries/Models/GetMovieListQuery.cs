using CinemaManagementSystem.Core.Bases;
using CinemaManagementSystem.Core.Features.Movies.Queries.Results;
using MediatR;

namespace CinemaManagementSystem.Core.Features.Movies.Queries.Models
{
    public class GetMovieListQuery : IRequest<Response<List<GetMovieListResponse>>>
    {

    }
}
