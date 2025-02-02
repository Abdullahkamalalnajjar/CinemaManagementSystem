using CinemaManagementSystem.Core.Bases;
using MediatR;

namespace CinemaManagementSystem.Core.Features.Theaters.Commands.Models
{
    public class DeleteTheaterCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}
