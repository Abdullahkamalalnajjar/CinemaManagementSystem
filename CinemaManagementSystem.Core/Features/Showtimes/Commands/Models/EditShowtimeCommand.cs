using CinemaManagementSystem.Core.Bases;
using MediatR;

namespace CinemaManagementSystem.Core.Features.Showtimes.Commands.Models
{
    public class EditShowtimeCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int TheaterId { get; set; }
        public DateTime StartTime { get; set; }
        public decimal SeatPrice { get; set; }
        public int AvailableSeats { get; set; }
    }
}
