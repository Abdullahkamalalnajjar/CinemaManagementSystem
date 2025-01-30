using CinemaManagementSystem.Core.Bases;
using CinemaManagementSystem.Core.Features.Showtimes.Queries.Results;
using MediatR;

namespace CinemaManagementSystem.Core.Features.Showtimes.Queries.Models
{
    public class GetShowtimeByIdQuery(int id) : IRequest<Response<GetShowtimeByIdResponse>>
    {
        public int Id { get; set; } = id;
    }
}
