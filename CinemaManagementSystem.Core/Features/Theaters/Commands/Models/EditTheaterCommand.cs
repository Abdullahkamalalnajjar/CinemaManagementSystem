using CinemaManagementSystem.Core.Bases;
using MediatR;

namespace CinemaManagementSystem.Core.Features.Theaters.Commands.Models
{
    public class EditTheaterCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string ScreenNumber { get; set; }
        public int TotalSeats { get; set; }
    }
}
