using AutoMapper;

namespace CinemaManagementSystem.Core.Mapping.Movies
{
    public partial class MovieProfiles : Profile
    {
        public MovieProfiles()
        {
            AddMovieCommandMapping();
            AddMovieCommandResponseMapping();
            EditMovieCommandMapping();
            GetMovieListResponseMapping();
            GetMoviePaginatedListResponseMapping();
        }
    }
}
