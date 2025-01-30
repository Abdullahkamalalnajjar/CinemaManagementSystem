using CinemaManagementSystem.Data.Entities;

namespace CinemaManagementSystem.Service.Abstract
{
    public interface IShowtimeService
    {
        public Task<string> AddShowtimeAsync(Showtime command);
        public Task<Showtime?> GetShowtimeByIdAsync(int id);

    }
}
