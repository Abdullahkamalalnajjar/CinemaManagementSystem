using CinemaManagementSystem.Core.Bases;
using MediatR;

namespace CinemaManagementSystem.Core.Features.ReservedSeats.Commands.Models
{
    public class DeleteReservedSeatCommand(int id) : IRequest<Response<string>>
    {
        public int Id { get; set; } = id;
    }
}
