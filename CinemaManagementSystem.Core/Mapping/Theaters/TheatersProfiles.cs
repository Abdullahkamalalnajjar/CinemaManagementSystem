using AutoMapper;

namespace CinemaManagementSystem.Core.Mapping.Theaters
{
    public partial class TheatersProfiles : Profile
    {
        public TheatersProfiles()
        {
            AddTheaterCommandMapper();
            EditTheaterCommandMapper();
            GetTheaterListQueryMapper();
        }
    }
}
