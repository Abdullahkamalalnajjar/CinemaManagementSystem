namespace CinemaManagementSystem.Data.Entities
{
    public class Movie
    {
        public int Id { get; set; } // المعرف الفريد للفيلم
        public string Title { get; set; } // اسم الفيلم
        public string Description { get; set; } // وصف الفيلم
        public string Type { get; set; } // النوع (مثل أكشن، دراما، كوميديا)
        public string AgeRating { get; set; } // تصنيف الأعمار (مثل PG-13 أو R)
        public int DurationMinutes { get; set; } // مدة الفيلم بالدقائق
        public string PosterUrl { get; set; } // رابط لصورة البوستر
        public DateTime ReleaseDate { get; set; } // تاريخ الإصدار
        public ICollection<Showtime> Showtimes { get; set; } // أوقات العرض المرتبطة بالفيلم
    }
}
