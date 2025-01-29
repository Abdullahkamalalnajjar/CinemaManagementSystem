using CinemaManagementSystem.Data.Entities;
using CinemaManagementSystem.Infruasturcture.Abstracts;
using CinemaManagementSystem.infrustructure.InfrustructureBase;
using CinemaManagementSystem.Infrustructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagementSystem.Infruasturcture.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        private readonly DbSet<Movie> _moviesRepository;
        public MovieRepository(ApplicationDbContext context) : base(context)
        {
            _moviesRepository = context.Set<Movie>();
        }

    }
}
