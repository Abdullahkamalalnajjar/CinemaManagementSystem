using CinemaManagementSystem.Core.Features.ReservationsShowtime.Queries.Results;
using CinemaManagementSystem.Data.Entities;

namespace CinemaManagementSystem.Core.Mapping.ReservationsShowTime
{
    public partial class ReservationProfiles
    {

        public void ApplyGetReservationListQueryMapper()
        {
            CreateMap<Reservation, GetReservationListResponse>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.AppUser.FullName))
                .ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src.Showtime.Movie.Title))
                .ForMember(dest => dest.Screen, opt => opt.MapFrom(src => src.Showtime.Theater.ScreenNumber))
                .ForMember(dest => dest.ReservedSeats, opt => opt.MapFrom(src => src.ReservedSeats));

            CreateMap<ReservedSeat, ReservedSeatsShowtime>();
        }

    }
}

