using CinemaManagementSystem.Core.Bases;
using MediatR;

namespace CinemaManagementSystem.Core.Features.ReservedSeats.Commands.Models
{
    public class EditReservedSeatCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public string SeatNumber { get; set; }
    }
}
