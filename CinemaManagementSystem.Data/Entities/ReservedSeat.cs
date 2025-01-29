namespace CinemaManagementSystem.Data.Entities
{
    public class ReservedSeat
    {
        public int Id { get; set; } // معرف المقعد المحجوز
        public int ReservationId { get; set; } // معرف الحجز المرتبط
        public Reservation Reservation { get; set; } // كيان الحجز المرتبط
        public string SeatNumber { get; set; } // رقم المقعد (مثل A1 أو B3)
    }

}
