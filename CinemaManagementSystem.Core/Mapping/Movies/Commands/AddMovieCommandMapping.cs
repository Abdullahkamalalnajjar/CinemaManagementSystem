using CinemaManagementSystem.Core.Features.Movies.Commands.Models;
using CinemaManagementSystem.Core.Features.Movies.Commands.Results;
using CinemaManagementSystem.Data.Entities;

namespace CinemaManagementSystem.Core.Mapping.Movies
{
    public partial class MovieProfiles
    {

        public void AddMovieCommandMapping()
        {
            CreateMap<AddMovieCommand, Movie>();
        }
        public void AddMovieCommandResponseMapping()
        {
            CreateMap<Movie, AddMovieCommandResponse>();
        }
    }
}
