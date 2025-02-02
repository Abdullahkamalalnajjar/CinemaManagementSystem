namespace CinemaManagementSystem.Core.Features.Showtimes.Queries.Results
{
    public class GetShowtimePaginatedListResponse
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
        public decimal SeatPrice { get; set; }
        public decimal TotalPrice => NumberOfSeats * SeatPrice;
    }
}
