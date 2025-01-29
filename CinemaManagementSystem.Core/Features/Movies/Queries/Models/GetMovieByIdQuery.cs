using CinemaManagementSystem.Core.Bases;
using CinemaManagementSystem.Data.Entities;
using MediatR;

namespace CinemaManagementSystem.Core.Features.Movies.Queries.Models
{
    public class GetMovieByIdQuery(int id) : IRequest<Response<Movie>>
    {
        public int Id { get; set; } = id;
    }
}
