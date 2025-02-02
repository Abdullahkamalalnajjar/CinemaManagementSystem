using CinemaManagementSystem.Data.Entities;
using CinemaManagementSystem.Data.Helpers;

namespace CinemaManagementSystem.Service.Abstract
{
    public interface IShowtimeService
    {
        public Task<string> AddShowtimeAsync(Showtime command);
        public Task<string> EditShowtimeAsync(Showtime showtime);
        public Task<string> DeleteShowtimeAsync(Showtime showtime);
        public Task<Showtime?> GetShowtimeByIdAsync(int id);
        public Task<bool> GetShowtimeByIdForValidatorAsync(int id);
        public Task<List<Showtime>> GetShowtimeListAsync();
        public IQueryable<Showtime> FilterShowtimeAsQueryable(string search, ShowtimeOrderingEnum showtimeOrderingEnum);

    }
}
