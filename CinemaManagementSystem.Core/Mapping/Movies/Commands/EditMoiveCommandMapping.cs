using CinemaManagementSystem.Core.Features.Movies.Commands.Models;
using CinemaManagementSystem.Data.Entities;

namespace CinemaManagementSystem.Core.Mapping.Movies
{
    public partial class MovieProfiles
    {

        public void EditMovieCommandMapping()
        {
            CreateMap<EditMovieCommand, Movie>();
        }

    }
}
