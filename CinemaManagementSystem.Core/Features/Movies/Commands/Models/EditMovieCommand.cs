using CinemaManagementSystem.Core.Bases;
using MediatR;

namespace CinemaManagementSystem.Core.Features.Movies.Commands.Models
{
    public class EditMovieCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string Title { get; set; } // اسم الفيلم
        public string Description { get; set; } // وصف الفيلم
        public string Type { get; set; } // النوع (مثل أكشن، دراما، كوميديا)
        public string AgeRating { get; set; } // تصنيف الأعمار (مثل PG-13 أو R)
        public int DurationMinutes { get; set; } // مدة الفيلم بالدقائق
        public string PosterUrl { get; set; } // رابط لصورة البوستر
        public DateTime ReleaseDate { get; set; } // تاريخ الإصدار
    }
}
