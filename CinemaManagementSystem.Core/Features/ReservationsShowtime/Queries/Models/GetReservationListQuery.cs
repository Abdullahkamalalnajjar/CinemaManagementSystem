using CinemaManagementSystem.Core.Bases;
using CinemaManagementSystem.Core.Features.ReservationsShowtime.Queries.Results;
using MediatR;

namespace CinemaManagementSystem.Core.Features.ReservationsShowtime.Queries.Models
{
    public class GetReservationListQuery : IRequest<Response<List<GetReservationListResponse>>>
    {

    }
}
