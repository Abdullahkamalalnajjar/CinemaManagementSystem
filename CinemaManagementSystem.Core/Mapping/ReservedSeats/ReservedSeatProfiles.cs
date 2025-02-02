using AutoMapper;

namespace CinemaManagementSystem.Core.Mapping.ReservedSeats
{
    public partial class ReservedSeatProfiles : Profile
    {
        public ReservedSeatProfiles()
        {
            ApplyCreateReservedSeatMappings();
            ApplyGetReservedSeatListMappings();
        }

    }
}
