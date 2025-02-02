using CinemaManagementSystem.Data.Entities;
using CinemaManagementSystem.Infruasturcture.Abstracts;
using CinemaManagementSystem.Service.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagementSystem.Service.Implementation
{
    public class ReservedSeatService : IReservedSeatService
    {
        private readonly IReservedSeatRepository _reservedSeatRepository;

        public ReservedSeatService(IReservedSeatRepository reservedSeatRepository)
        {
            _reservedSeatRepository = reservedSeatRepository;
        }
        public async Task<string> CreateReservedSeatAsync(ReservedSeat reservedSeat)
        {
            await _reservedSeatRepository.AddAsync(reservedSeat);
            return "Added";
        }

        public async Task<string> DeleteReservedSeatAsync(ReservedSeat reservedSeat)
        {
            await _reservedSeatRepository.DeleteAsync(reservedSeat);
            return "Deleted";
        }

        public async Task<string> EditReservedSeatAsync(ReservedSeat reservedSeat)
        {
            await _reservedSeatRepository.UpdateAsync(reservedSeat);
            return "Updated";
        }

        public async Task<ReservedSeat?> GetReservedSeatByIdAsync(int id)

          => await _reservedSeatRepository.GetTableNoTracking().Include(r => r.Reservation).FirstOrDefaultAsync(x => x.Id == id);



        public async Task<List<ReservedSeat>> GetReservedSeatListAsync()

         => await _reservedSeatRepository.GetTableNoTracking()
            .Include(r => r.Reservation)
            .Include(r => r.Reservation.AppUser)
            .ToListAsync();


    }
}
