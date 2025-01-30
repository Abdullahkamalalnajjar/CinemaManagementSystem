using CinemaManagementSystem.Data.Entities;
using CinemaManagementSystem.Data.Helpers;

namespace CinemaManagementSystem.Service.Abstract
{
    public interface ITheaterService
    {
        public Task<string> AddTheaterAsync(Theater theater);
        public Task<bool> IsTheaterExist(string theaterName);
        public Task<bool> IsTheaterByIdExist(int theaterId);
        public Task<bool> IsScreenNumberExistExcludeSelf(int id, string screenNum);
        public Task<Theater?> GetTheaterByIdAsync(int id);
        public Task<List<Theater>> GetTheaterListAsync();
        public IQueryable<Theater> GetTheatersAsQueryable();
        public Task<string> EditTheaterAsync(Theater theater);
        public IQueryable<Theater> FilterTheaterAsQueryable(string search, TheaterOrdering theaterOrdering);


    }
}
