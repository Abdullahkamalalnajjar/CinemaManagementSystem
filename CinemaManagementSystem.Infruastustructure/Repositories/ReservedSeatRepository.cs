using CinemaManagementSystem.Data.Entities;
using CinemaManagementSystem.Infruasturcture.Abstracts;
using CinemaManagementSystem.infrustructure.InfrustructureBase;
using CinemaManagementSystem.Infrustructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagementSystem.Infruasturcture.Repositories
{
    public class ReservedSeatRepository : GenericRepository<ReservedSeat>, IReservedSeatRepository
    {
        private readonly DbSet<ReservedSeat> _reservedSeatsRepository;
        public ReservedSeatRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _reservedSeatsRepository = dbContext.Set<ReservedSeat>();
        }
    }
}
