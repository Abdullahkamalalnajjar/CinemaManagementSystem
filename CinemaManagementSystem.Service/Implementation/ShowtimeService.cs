using CinemaManagementSystem.Data.Entities;
using CinemaManagementSystem.Data.Helpers;
using CinemaManagementSystem.Infruasturcture.Abstracts;
using CinemaManagementSystem.Service.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagementSystem.Service.Implementation
{
    public class ShowtimeService : IShowtimeService
    {
        private readonly IShowtimeRepository _showtimeRepository;

        public ShowtimeService(IShowtimeRepository showtimeRepository)
        {
            _showtimeRepository = showtimeRepository;
        }
        public async Task<string> AddShowtimeAsync(Showtime command)
        {
            await _showtimeRepository.AddAsync(command);
            return "Added";
        }

        public async Task<string> DeleteShowtimeAsync(Showtime showtime)
        {
            await _showtimeRepository.DeleteAsync(showtime);
            return "Deleted";
        }

        public async Task<string> EditShowtimeAsync(Showtime showtime)
        {
            await _showtimeRepository.UpdateAsync(showtime);
            return "Updated";
        }

        public IQueryable<Showtime> FilterShowtimeAsQueryable(string search, ShowtimeOrderingEnum showtimeOrderingEnum)
        {
            var showtimes = _showtimeRepository.GetTableNoTracking()
                .Include(m => m.Movie)
                .Include(t => t.Theater)
                .AsQueryable();
            if (!string.IsNullOrEmpty(search))
                showtimes = showtimes.Where(x => x.Movie.Title.Contains(search) || x.Theater.ScreenNumber.Contains(search));
            return showtimeOrderingEnum switch
            {
                ShowtimeOrderingEnum.StartTime => showtimes.OrderBy(x => x.StartTime),
                ShowtimeOrderingEnum.SeatPrice => showtimes.OrderBy(x => x.SeatPrice),
                _ => showtimes.OrderBy(x => x.Id)
            };

        }

        public async Task<Showtime?> GetShowtimeByIdAsync(int id)
        {
            var result = await _showtimeRepository.GetTableNoTracking()
                .Include(r => r.Reservations)
                .Include(m => m.Movie)
                .Include(t => t.Theater)
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<bool> GetShowtimeByIdForValidatorAsync(int id)
        {
            var result = await _showtimeRepository.GetTableNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
                return false;
            return true;
        }


        public async Task<List<Showtime>> GetShowtimeListAsync()
        {
            var result = await _showtimeRepository.GetTableNoTracking()
                .Include(r => r.Reservations)
                .Include(m => m.Movie)
                .Include(t => t.Theater).ToListAsync();
            return result;
        }
    }
}
