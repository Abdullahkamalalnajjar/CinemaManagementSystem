using CinemaManagementSystem.Core.Features.Showtimes.Queries.Results;
using CinemaManagementSystem.Core.Features.Theaters.Queries.Results;
using CinemaManagementSystem.Data.Entities;

namespace CinemaManagementSystem.Core.Mapping.Showtimes
{
    public partial class ShowtimeProfiles
    {

        public void GetShowtimeByIdQueryMapper()
        {
            CreateMap<Showtime, GetShowtimeByIdResponse>()
                .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.Movie.Title))
                .ForMember(dest => dest.Reservations, opt => opt.MapFrom(src => src.Reservations))
                .ForMember(dest => dest.TheaterName, opt => opt.MapFrom(src => src.Theater.ScreenNumber));

            CreateMap<Reservation, Reservations>()
                .ForMember(dest => dest.AppUserName, opt => opt.MapFrom(src => src.AppUser.UserName));
        }

    }
}
