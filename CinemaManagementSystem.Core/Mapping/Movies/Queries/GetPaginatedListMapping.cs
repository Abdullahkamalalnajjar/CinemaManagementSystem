using CinemaManagementSystem.Core.Features.Movies.Queries.Results;
using CinemaManagementSystem.Data.Entities;

namespace CinemaManagementSystem.Core.Mapping.Movies
{
    public partial class MovieProfiles
    {


        public void GetMoviePaginatedListResponseMapping()
        {
            CreateMap<Movie, GetMoviePaginatedListResponse>();
        }
    }
}

