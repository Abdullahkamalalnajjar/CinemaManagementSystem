using CinemaManagementSystem.Core.Features.Showtimes.Queries.Results;
using CinemaManagementSystem.Core.Wrappers;
using CinemaManagementSystem.Data.Helpers;
using MediatR;

namespace CinemaManagementSystem.Core.Features.Showtimes.Queries.Models
{
    public class GetShowtimePaginatedListQuery : IRequest<PaginatedResult<GetShowtimePaginatedListResponse>>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public string? Search { get; set; }

        public ShowtimeOrderingEnum ShowtimeOrderingEnum { get; set; }
    }
}
