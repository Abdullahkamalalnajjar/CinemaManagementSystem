using CinemaManagementSystem.Data.Entities;

namespace CinemaManagementSystem.Service.Abstract
{
    public interface ITheaterService
    {
        public Task<string> AddTheaterAsync(Theater theater);
        public Task<bool> IsTheaterExist(string theaterName);
        public Task<bool> IsScreenNumberExistExcludeSelf(int id, string screenNum);
        public Task<Theater?> GetTheaterByIdAsync(int id);
        public Task<List<Theater>> GetTheaterListAsync();
        public Task<string> EditTheaterAsync(Theater theater);

    }
}
