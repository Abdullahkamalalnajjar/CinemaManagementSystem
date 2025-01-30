using CinemaManagementSystem.Core.Features.Theaters.Queries.Results;

namespace CinemaManagementSystem.Core.Features.Showtimes.Queries.Results
{
    public class GetShowtimeByIdResponse
    {
        public string MovieName { get; set; }
        public string TheaterName { get; set; }
        public DateTime StartTime { get; set; }
        public decimal SeatPrice { get; set; }
        public int AvailableSeats { get; set; }
        public List<Reservations> Reservations { get; set; }
    }
}
