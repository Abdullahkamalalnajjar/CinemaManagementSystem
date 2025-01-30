using CinemaManagementSystem.Data.Entities;
using CinemaManagementSystem.Infruasturcture.Abstracts;
using CinemaManagementSystem.infrustructure.InfrustructureBase;
using CinemaManagementSystem.Infrustructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagementSystem.Infruasturcture.Repositories
{
    public class TheaterRepository : GenericRepository<Theater>, ITheaterRepository
    {
        private readonly DbSet<Theater> _theaters;
        public TheaterRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _theaters = dbContext.Set<Theater>();
        }

    }
}
