using AutoMapper;

namespace CinemaManagementSystem.Core.Mapping.Showtimes
{
    public partial class ShowtimeProfiles : Profile
    {
        public ShowtimeProfiles()
        {
            AddShowtimeCommandMapper();
            EditShowtimeCommandMapper();
            GetShowtimeByIdQueryMapper();
            GetShowtimePaginatedListResponseMapper();
        }
    }
}
