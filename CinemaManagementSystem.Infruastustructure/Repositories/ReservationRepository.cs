using CinemaManagementSystem.Data.Entities;
using CinemaManagementSystem.Infruasturcture.Abstracts;
using CinemaManagementSystem.infrustructure.InfrustructureBase;
using CinemaManagementSystem.Infrustructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagementSystem.Infruasturcture.Repositories
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        private readonly DbSet<Reservation> _reservationsRepository;
        public ReservationRepository(ApplicationDbContext context) : base(context)
        {
            _reservationsRepository = context.Set<Reservation>();
        }
    }
}
