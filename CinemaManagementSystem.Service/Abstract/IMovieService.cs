using CinemaManagementSystem.Data.Entities;
using CinemaManagementSystem.Date.Helpers;

namespace CinemaManagementSystem.Service.Abstract
{
    public interface IMovieService
    {
        public Task<bool> IsMovieExist(string movieName);
        public Task<bool> IsMovieByIdExist(int movieId);
        public Task<bool> IsTitleExistExcludeSelf(int id, string title);
        public Task<Movie> AddMovieAsync(Movie movie);
        public Task<string> EditMovieAsync(Movie movie);
        public Task<List<Movie>> GetMovieListAsync();
        public Task<Movie?> GetMovieByIdAsync(int id);
        public Task<string> DeleteMovieByIdAsync(int id);
        public IQueryable<Movie> FilterMoviePaginatedQueryable(MoiveOrderingEnum moiveOrderingEnum, string title);
    }
}
