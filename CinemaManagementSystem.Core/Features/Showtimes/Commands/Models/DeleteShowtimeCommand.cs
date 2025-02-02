using CinemaManagementSystem.Core.Bases;
using MediatR;

namespace CinemaManagementSystem.Core.Features.Showtimes.Commands.Models
{
    public class DeleteShowtimeCommand(int id) : IRequest<Response<string>>
    {
        public int Id { get; set; } = id;
    }
}
