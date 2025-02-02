using CinemaManagementSystem.Core.Bases;
using MediatR;

namespace CinemaManagementSystem.Core.Features.ReservedSeats.Commands.Models
{
    public class CreateReservedSeatCommand : IRequest<Response<string>>
    {
        public int ReservationId { get; set; }
        public string SeatNumber { get; set; }
    }
}
