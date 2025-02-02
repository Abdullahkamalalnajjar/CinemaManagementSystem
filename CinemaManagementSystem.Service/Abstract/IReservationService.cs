using CinemaManagementSystem.Data.Entities;

namespace CinemaManagementSystem.Service.Abstract
{
    public interface IReservationService
    {
        public Task<string> CreateReservationAsync(Reservation reservation);
        public Task<string> EditReservationAsync(Reservation reservation);
        public Task<string> DeleteReservationAsync(Reservation reservation);
        public Task<List<Reservation>> GetReservationListAsync();
        public Task<Reservation> GetReservationByIdAsync(int id);
    }
}
