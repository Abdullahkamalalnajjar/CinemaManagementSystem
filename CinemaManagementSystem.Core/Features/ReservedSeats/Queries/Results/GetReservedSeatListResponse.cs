namespace CinemaManagementSystem.Core.Features.ReservedSeats.Queries.Results
{
    public class GetReservedSeatListResponse
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public int ShowtimeId { get; set; }
        public string AppUserId { get; set; }
        public string UserName { get; set; }
        public string SeatNumber { get; set; }
        public int NumberOfSeats { get; set; }
        public DateTime ReservationDate { get; set; }

    }
}
