using CinemaManagementSystem.Core.Bases;
using MediatR;
namespace CinemaManagementSystem.Core.Features.ReservationsShowtime.Commands.Models
{
    public class CreateReservationCommand : IRequest<Response<string>>
    {
        public string AppUserId { get; set; }
        public int ShowtimeId { get; set; }
        public int NumberOfSeats { get; set; }
        public decimal SeatPrice { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}
