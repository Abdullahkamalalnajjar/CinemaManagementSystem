using CinemaManagementSystem.Data.Entities.Identity;

namespace CinemaManagementSystem.Data.Entities
{
    public class Reservation
    {
        public int Id { get; set; } // معرف الحجز
        public string AppUserId { get; set; } // معرف المستخدم الذي قام بالحجز
        public AppUser AppUser { get; set; } // كيان المستخدم المرتبط
        public int ShowtimeId { get; set; } // معرف وقت العرض المرتبط
        public Showtime Showtime { get; set; } // كيان وقت العرض المرتبط
        public ICollection<ReservedSeat> ReservedSeats { get; set; } // المقاعد المحجوزة
        public decimal TotalPrice => NumberOfSeats * SeatPrice; // يتم حسابه ديناميكيًا
        public int NumberOfSeats { get; set; } // عدد المقاعد المحجوزة
        public decimal SeatPrice { get; set; } // سعر المقعد الواحد
        public DateTime ReservationDate { get; set; } // تاريخ الحجز
    }

}
