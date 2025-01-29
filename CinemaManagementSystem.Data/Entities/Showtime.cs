namespace CinemaManagementSystem.Data.Entities
{
    public class Showtime
    {
        public int Id { get; set; } // معرف وقت العرض
        public int MovieId { get; set; } // معرف الفيلم المرتبط
        public Movie Movie { get; set; } // كيان الفيلم المرتبط
        public int TheaterId { get; set; } // معرف القاعه المرتبطة
        public Theater Theater { get; set; } // كيان القاعه المرتبطة
        public DateTime StartTime { get; set; } // وقت بدء العرض
        public decimal SeatPrice { get; set; } // سعر المقعد لهذا العرض
        public int AvailableSeats { get; set; } // عدد المقاعد المتاحة
        public ICollection<Reservation> Reservations { get; set; } // الحجوزات المرتبطة بوقت العرض
    }
}
