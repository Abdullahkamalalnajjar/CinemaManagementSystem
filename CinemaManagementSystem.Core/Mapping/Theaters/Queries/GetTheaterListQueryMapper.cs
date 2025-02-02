using CinemaManagementSystem.Core.Features.Theaters.Queries.Results;
using CinemaManagementSystem.Data.Entities;

namespace CinemaManagementSystem.Core.Mapping.Theaters
{
    public partial class TheatersProfiles
    {

        public void GetTheaterListQueryMapper()
        {
            CreateMap<Theater, GetTheaterListResponse>();
            CreateMap<Showtime, ShowTime>()
                .ForMember(dest => dest.TheaterName, opt => opt.MapFrom(src => src.Theater.ScreenNumber))
                .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.Movie.Title))
                .ForMember(dest => dest.AvailableSeats, opt => opt.MapFrom(src => src.Theater.TotalSeats - src.Reservations.Count));
            CreateMap<Reservation, Reservations>()
                .ForMember(dest => dest.AppUserName, opt => opt.MapFrom(src => src.AppUser.FullName))
                .ForMember(dest => dest.NumberOfSeats, opt => opt.MapFrom(src => src.NumberOfSeats))
                .ForMember(dest => dest.ReservationDate, opt => opt.MapFrom(src => src.ReservationDate));
        }
    }
}
