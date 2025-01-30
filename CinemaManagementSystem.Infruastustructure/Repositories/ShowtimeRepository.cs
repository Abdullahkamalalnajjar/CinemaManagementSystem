using CinemaManagementSystem.Data.Entities;
using CinemaManagementSystem.Infruasturcture.Abstracts;
using CinemaManagementSystem.infrustructure.InfrustructureBase;
using CinemaManagementSystem.Infrustructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagementSystem.Infruasturcture.Repositories
{
    public class ShowtimeRepository : GenericRepository<Showtime>, IShowtimeRepository
    {
        private readonly DbSet<Showtime> _showTimeRepository;
        public ShowtimeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _showTimeRepository = dbContext.Set<Showtime>();
        }

    }
}
