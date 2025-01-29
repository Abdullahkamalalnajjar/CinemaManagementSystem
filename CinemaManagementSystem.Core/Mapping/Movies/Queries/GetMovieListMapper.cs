using CinemaManagementSystem.Core.Features.Movies.Queries.Results;
using CinemaManagementSystem.Data.Entities;

namespace CinemaManagementSystem.Core.Mapping.Movies
{
    public partial class MovieProfiles
    {


        public void GetMovieListResponseMapping()
        {
            CreateMap<Movie, GetMovieListResponse>();
        }
    }
}
