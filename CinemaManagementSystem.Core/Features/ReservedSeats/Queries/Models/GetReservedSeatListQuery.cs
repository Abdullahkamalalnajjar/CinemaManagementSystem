using CinemaManagementSystem.Core.Bases;
using CinemaManagementSystem.Core.Features.ReservedSeats.Queries.Results;
using MediatR;

namespace CinemaManagementSystem.Core.Features.ReservedSeats.Queries.Models
{
    public class GetReservedSeatListQuery : IRequest<Response<List<GetReservedSeatListResponse>>>
    {
    }
}
