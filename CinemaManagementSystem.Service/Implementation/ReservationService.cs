using CinemaManagementSystem.Data.Entities;
using CinemaManagementSystem.Infruasturcture.Abstracts;
using CinemaManagementSystem.Service.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagementSystem.Service.Implementation
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public async Task<string> CreateReservationAsync(Reservation reservation)
        {
            await _reservationRepository.AddAsync(reservation);
            return "Added";
        }

        public async Task<string> DeleteReservationAsync(Reservation reservation)
        {
            await _reservationRepository.DeleteAsync(reservation);
            return "Deleted";
        }

        public async Task<string> EditReservationAsync(Reservation reservation)
        {
            await _reservationRepository.UpdateAsync(reservation);
            return "Updated";
        }

        public Task<Reservation> GetReservationByIdAsync(int id)
        {
            var reservation = _reservationRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return reservation;
        }

        public async Task<List<Reservation>> GetReservationListAsync()
        {
            var reservationList = await _reservationRepository.GetTableNoTracking()
                .Include(us => us.AppUser)
                .Include(s => s.Showtime)
                .Include(s => s.Showtime.Movie)
                .Include(s => s.Showtime.Theater)
                .Include(s => s.ReservedSeats)
                .ToListAsync();
            return reservationList;
        }
    }
}
