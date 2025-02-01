using CinemaManagementSystem.Core.Bases;
using CinemaManagementSystem.Core.Features.Showtimes.Queries.Results;
using MediatR;

namespace CinemaManagementSystem.Core.Features.Showtimes.Queries.Models
{
    public class GetShowtimeListQuery : IRequest<Response<List<GetShowtimeByIdResponse>>>
    {
    }
}
