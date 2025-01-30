using CinemaManagementSystem.Core.Bases;
using MediatR;

namespace CinemaManagementSystem.Core.Features.Movies.Commands.Models
{
    public class DeleteMovieCommand(int id) : IRequest<Response<string>>
    {
        public int Id
        {
            get; set;
        } = id;
    }
}
