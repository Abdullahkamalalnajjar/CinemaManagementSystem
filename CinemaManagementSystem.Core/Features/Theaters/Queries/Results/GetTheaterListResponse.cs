namespace CinemaManagementSystem.Core.Features.Theaters.Queries.Results
{
    public class GetTheaterListResponse
    {
        public int Id { get; set; }
        public string ScreenNumber { get; set; }
        public int TotalSeats { get; set; }
        public List<ShowTime> Showtimes { get; set; } = new List<ShowTime>();
    }

    public class ShowTime
    {
        public string MovieName { get; set; }
        public string TheaterName { get; set; }
        public DateTime StartTime { get; set; }
        public decimal SeatPrice { get; set; }
        public int AvailableSeats { get; set; }
        public List<Reservations> Reservations { get; set; }
    }

    public class Reservations
    {
        public string AppUserName { get; set; }
        public int NumberOfSeats { get; set; }

        public DateTime ReservationDate { get; set; }
    }
}
