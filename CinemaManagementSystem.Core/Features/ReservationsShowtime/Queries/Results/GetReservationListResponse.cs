namespace CinemaManagementSystem.Core.Features.ReservationsShowtime.Queries.Results
{
    public class GetReservationListResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Screen { get; set; }
        public string Movie { get; set; }
        public decimal TotalPrice => NumberOfSeats * SeatPrice;
        public int NumberOfSeats { get; set; }
        public decimal SeatPrice { get; set; }
        public DateTime ReservationDate { get; set; }
        public List<ReservedSeatsShowtime> ReservedSeats { get; set; }

    }
    public class ReservedSeatsShowtime
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public string SeatNumber { get; set; }
    }
}
