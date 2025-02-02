using CinemaManagementSystem.Core.Features.Showtimes.Queries.Results;
using CinemaManagementSystem.Data.Entities;

namespace CinemaManagementSystem.Core.Mapping.Showtimes
{
    public partial class ShowtimeProfiles
    {

        public void GetShowtimePaginatedListResponseMapper()
        {
            CreateMap<Showtime, GetShowtimePaginatedListResponse>()
                .ForMember(dest => dest.TheaterName, opt => opt.MapFrom(src => src.Theater.ScreenNumber))
                .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.Movie.Title))
                .ForMember(dest => dest.Reservations, opt => opt.MapFrom(src => src.Reservations));

            CreateMap<Reservation, Reservations>()
                .ForMember(dest => dest.AppUserName, opt => opt.MapFrom(src => src.AppUser.UserName))
                .ForMember(dest => dest.NumberOfSeats, opt => opt.MapFrom(src => src.NumberOfSeats))
                .ForMember(dest => dest.ReservationDate, opt => opt.MapFrom(src => src.ReservationDate));
        }
    }

}
