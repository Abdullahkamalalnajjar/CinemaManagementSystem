using CinemaManagementSystem.Core.Features.Theaters.Queries.Results;
using CinemaManagementSystem.Core.Wrappers;
using CinemaManagementSystem.Data.Helpers;
using MediatR;

namespace CinemaManagementSystem.Core.Features.Theaters.Queries.Models
{
    public class GetTheaterPaginatedListQuery : IRequest<PaginatedResult<GetTheaterListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Search { get; set; }
        public TheaterOrdering TheaterOrdering { get; set; }
    }
}
