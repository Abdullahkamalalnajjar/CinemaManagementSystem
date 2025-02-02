using AutoMapper;

namespace CinemaManagementSystem.Core.Mapping.ReservationsShowTime
{
    public partial class ReservationProfiles : Profile
    {
        public ReservationProfiles()
        {
            ApplyCreateReservationCommandMapper();
            ApplyEditReservationCommandMapper();
            ApplyGetReservationListQueryMapper();
        }
    }
}
