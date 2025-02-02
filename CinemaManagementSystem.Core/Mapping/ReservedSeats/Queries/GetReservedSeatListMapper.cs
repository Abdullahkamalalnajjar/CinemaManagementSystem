using CinemaManagementSystem.Core.Features.ReservedSeats.Queries.Results;
using CinemaManagementSystem.Data.Entities;

namespace CinemaManagementSystem.Core.Mapping.ReservedSeats
{
    public partial class ReservedSeatProfiles
    {

        public void ApplyGetReservedSeatListMappings()
        {
            CreateMap<ReservedSeat, GetReservedSeatListResponse>()
                .ForMember(dest => dest.ShowtimeId, opt => opt.MapFrom(src => src.Reservation.ShowtimeId))
                .ForMember(dest => dest.AppUserId, opt => opt.MapFrom(src => src.Reservation.AppUserId))
                .ForMember(dest => dest.NumberOfSeats, opt => opt.MapFrom(src => src.Reservation.NumberOfSeats))
                .ForMember(dest => dest.SeatNumber, opt => opt.MapFrom(src => src.SeatNumber))
                .ForMember(dest => dest.ReservationDate, opt => opt.MapFrom(src => src.Reservation.ReservationDate))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Reservation.AppUser.FullName));
        }
    }
}