using CinemaManagementSystem.Data.Entities;
using CinemaManagementSystem.Data.Helpers;
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

        public async Task<bool> IsTheaterByIdExist(int theaterId)
        {
            var result = await _theaterRepository.GetTableNoTracking().Where(x => x.Id == theaterId).FirstOrDefaultAsync();
            return result is not null;
        }

        public IQueryable<Theater> GetTheatersAsQueryable()
            => _theaterRepository.GetTableNoTracking().Include(s => s.Showtimes).AsQueryable();
        public IQueryable<Theater> FilterTheaterAsQueryable(string search, TheaterOrdering theaterOrdering)
        {
            var theaters = _theaterRepository.GetTableNoTracking().Include(s => s.Showtimes).AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                theaters = theaters.Where(x => x.ScreenNumber.Contains(search));
            }
            return theaterOrdering switch
            {
                TheaterOrdering.ScreenNumber => theaters.OrderBy(x => x.ScreenNumber),
                TheaterOrdering.TotalSeats => theaters.OrderBy(x => x.TotalSeats),
                _ => theaters.OrderBy(x => x.Id)
            };

        }

    }
}
