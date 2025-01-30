using CinemaManagementSystem.Core.Bases;
using MediatR;

namespace CinemaManagementSystem.Core.Features.Theaters.Commands.Models
{
    public class AddTheaterCommand : IRequest<Response<string>>
    {
        public string ScreenNumber { get; set; }
        public int TotalSeats { get; set; }
    }
}
