namespace CinemaManagementSystem.Core.Features.Movies.Queries.Results
{
    public class GetMoviePaginatedListResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string AgeRating { get; set; }
        public int DurationMinutes { get; set; }
        public string PosterUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
