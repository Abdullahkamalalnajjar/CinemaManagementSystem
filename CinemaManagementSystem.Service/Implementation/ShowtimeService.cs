using CinemaManagementSystem.Data.Entities;
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
        public async Task<Showtime?> GetShowtimeByIdAsync(int id)
        {
            var result = await _showtimeRepository.GetTableNoTracking()
                .Include(r => r.Reservations)
                .Include(m => m.Movie)
                .Include(t => t.Theater)
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
}
