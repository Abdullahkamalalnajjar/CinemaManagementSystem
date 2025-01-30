using CinemaManagementSystem.Data.Entities;
using CinemaManagementSystem.Infruasturcture.Abstracts;
using CinemaManagementSystem.Service.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagementSystem.Service.Implementation
{
    public class TheaterService : ITheaterService
    {
        private readonly ITheaterRepository _theaterRepository;

        public TheaterService(ITheaterRepository theaterRepository)
        {
            _theaterRepository = theaterRepository;
        }
        public async Task<string> AddTheaterAsync(Theater theater)
        {
            await _theaterRepository.AddAsync(theater);
            return "Added";
        }
        public async Task<bool> IsTheaterExist(string screenNumber)
        {
            var result = await _theaterRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.ScreenNumber == screenNumber);
            return result is not null;
        }
        public async Task<bool> IsScreenNumberExistExcludeSelf(int id, string screenNum)
        {
            var result = await _theaterRepository.GetTableNoTracking()
                .Where(n => n.ScreenNumber.Equals(screenNum) & !n.Id.Equals(id)).FirstOrDefaultAsync();
            return result is not null;
        }

        public async Task<string> EditTheaterAsync(Theater theater)
        {

            await _theaterRepository.UpdateAsync(theater);
            return "Updated";
        }

        public async Task<Theater?> GetTheaterByIdAsync(int id)
        {
            var result = await _theaterRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public Task<List<Theater>> GetTheaterListAsync()
        {
            var result = _theaterRepository.GetTableNoTracking()
                .Include(x => x.Showtimes).ThenInclude(s => s.Reservations)
                .Include(x => x.Showtimes).ThenInclude(s => s.Movie)
                .ToListAsync();
            return result;
        }
    }
}
