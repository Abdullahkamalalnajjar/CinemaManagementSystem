namespace CinemaManagementSystem.Data.Entities
{
    public class Theater
    {
        public int Id { get; set; } // معرف الشاشة
        public string ScreenNumber { get; set; } // رقم الشاشة
        public int TotalSeats { get; set; } // عدد المقاعد الإجمالي في الشاشة
        public ICollection<Showtime> Showtimes { get; set; } // العروض المرتبطة بالشاشة
    }

}
