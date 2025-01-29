using CinemaManagementSystem.Data.Entities;
using CinemaManagementSystem.Date.Helpers;
using CinemaManagementSystem.Infruasturcture.Abstracts;
using CinemaManagementSystem.Service.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagementSystem.Service.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Movie> AddMovieAsync(Movie movie)
        {
            var result = await _movieRepository.AddAsync(movie);
            return result;
        }

        public async Task<string> EditMovieAsync(Movie movie)
        {
            await _movieRepository.UpdateAsync(movie);
            return "Updated";
        }

        public IQueryable<Movie> FilterMoviePaginatedQueryable(MoiveOrderingEnum moiveOrderingEnum, string title)
        {
            var movies = _movieRepository.GetTableNoTracking().Include(s => s.Showtimes).AsQueryable();
            if (!string.IsNullOrEmpty(title))
            {
                movies = movies.Where(x => x.Title.Contains(title));
            }
            return moiveOrderingEnum switch
            {
                MoiveOrderingEnum.AgeRating => movies.OrderBy(x => x.AgeRating),
                MoiveOrderingEnum.DurationMinutes => movies.OrderBy(x => x.DurationMinutes),
                _ => movies.OrderBy(x => x.Id)
            };
        }

        public async Task<Movie?> GetMovieByIdAsync(int id)
        {
            var result = await _movieRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<List<Movie>> GetMovieListAsync()
        {
            var result = await _movieRepository.GetTableNoTracking().Include(s => s.Showtimes).ToListAsync();
            return result ?? new List<Movie>();
        }

        public async Task<bool> IsMovieExist(string movieName)
        {
            var result = await _movieRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.Title == movieName);
            return result is not null;
        }
        public async Task<bool> IsTitleExistExcludeSelf(int id, string title)
        {
            var result = await _movieRepository.GetTableNoTracking().Include(s => s.Showtimes)
                .Where(n => n.Title.Equals(title) & !n.Id.Equals(id)).FirstOrDefaultAsync();
            return result is not null;
        }

    }
}
