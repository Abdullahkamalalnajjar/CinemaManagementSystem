using CinemaManagementSystem.Core.Features.Showtimes.Commands.Models;
using CinemaManagementSystem.Data.Entities;

namespace CinemaManagementSystem.Core.Mapping.Showtimes
{
    public partial class ShowtimeProfiles
    {

        public void AddShowtimeCommandMapper()
        {
            CreateMap<AddShowtimeCommand, Showtime>();
        }
    }
}
