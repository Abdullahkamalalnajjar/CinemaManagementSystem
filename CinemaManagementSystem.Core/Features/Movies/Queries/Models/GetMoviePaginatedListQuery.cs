using CinemaManagementSystem.Core.Features.Movies.Queries.Results;
using CinemaManagementSystem.Core.Wrappers;
using CinemaManagementSystem.Date.Helpers;
using MediatR;

namespace CinemaManagementSystem.Core.Features.Movies.Queries.Models
{
    public class GetMoviePaginatedListQuery : IRequest<PaginatedResult<GetMoviePaginatedListResponse>>
    {


        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public MoiveOrderingEnum MovieOrderingEnum { get; set; }
        public string? Search { get; set; }

    }
}
