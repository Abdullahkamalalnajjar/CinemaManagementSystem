using CinemaManagementSystem.Core.Features.ReservationsShowtime.Commands.Models;
using CinemaManagementSystem.Data.Entities;

namespace CinemaManagementSystem.Core.Mapping.ReservationsShowTime
{
    public partial class ReservationProfiles
    {


        public void ApplyEditReservationCommandMapper()
        {
            CreateMap<EditReservationCommand, Reservation>();
        }


    }
}
