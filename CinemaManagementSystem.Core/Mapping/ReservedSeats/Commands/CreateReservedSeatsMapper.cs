using CinemaManagementSystem.Core.Features.ReservedSeats.Commands.Models;
using CinemaManagementSystem.Data.Entities;

namespace CinemaManagementSystem.Core.Mapping.ReservedSeats
{
    public partial class ReservedSeatProfiles
    {

        public void ApplyCreateReservedSeatMappings()
        {
            CreateMap<CreateReservedSeatCommand, ReservedSeat>();
        }
    }
}