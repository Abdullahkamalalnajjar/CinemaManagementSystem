using CinemaManagementSystem.Core.Bases;
using MediatR;

namespace CinemaManagementSystem.Core.Features.ReservationsShowtime.Commands.Models
{
    public class DeleteReservationCommand(int id) : IRequest<Response<string>>
    {
        public int Id { get; set; } = id;
    }
}
