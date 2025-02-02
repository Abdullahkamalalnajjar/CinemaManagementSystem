using CinemaManagementSystem.Data.Entities;

namespace CinemaManagementSystem.Service.Abstract
{
    public interface IReservedSeatService
    {

        public Task<string> CreateReservedSeatAsync(ReservedSeat reservedSeat);
        public Task<string> EditReservedSeatAsync(ReservedSeat reservedSeat);
        public Task<string> DeleteReservedSeatAsync(ReservedSeat reservedSeat);
        public Task<List<ReservedSeat>> GetReservedSeatListAsync();
        public Task<ReservedSeat?> GetReservedSeatByIdAsync(int id);
    }
}
