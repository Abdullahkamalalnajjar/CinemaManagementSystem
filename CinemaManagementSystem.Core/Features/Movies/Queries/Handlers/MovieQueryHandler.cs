using AutoMapper;
using CinemaManagementSystem.Core.Bases;
using CinemaManagementSystem.Core.Features.Movies.Queries.Models;
using CinemaManagementSystem.Core.Features.Movies.Queries.Results;
using CinemaManagementSystem.Core.Resources;
using CinemaManagementSystem.Core.Wrappers;
using CinemaManagementSystem.Data.Entities;
using CinemaManagementSystem.Service.Abstract;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CinemaManagementSystem.Core.Features.Movies.Queries.Handlers
{
    public class MovieQueryHandler : ResponseHandler,
        IRequestHandler<GetMovieListQuery, Response<List<GetMovieListResponse>>>,
        IRequestHandler<GetMovieByIdQuery, Response<Movie>>,
        IRequestHandler<GetMoviePaginatedListQuery, PaginatedResult<GetMoviePaginatedListResponse>>
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MovieQueryHandler(IStringLocalizer<SharedResources> localizer, IMovieService movieService, IMapper mapper) : base(localizer)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        public async Task<Response<List<GetMovieListResponse>>> Handle(GetMovieListQuery request, CancellationToken cancellationToken)
        {
            var movies = await _movieService.GetMovieListAsync();
            var resultsMapper = _mapper.Map<List<GetMovieListResponse>>(movies);
            return Success(resultsMapper);
        }

        public async Task<Response<Movie>> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            var movie = await _movieService.GetMovieByIdAsync(request.Id);
            if (movie is null) return NotFound<Movie>("Movie not found");
            return Success(movie);
        }



        Task<PaginatedResult<GetMoviePaginatedListResponse>> IRequestHandler<GetMoviePaginatedListQuery, PaginatedResult<GetMoviePaginatedListResponse>>.Handle(GetMoviePaginatedListQuery request, CancellationToken cancellationToken)
        {

            IQueryable<Movie> moviesQuerable = _movieService.FilterMoviePaginatedQueryable(request.MovieOrderingEnum, request.Search ?? string.Empty);
            var moviesMapper = _mapper.ProjectTo<GetMoviePaginatedListResponse>(moviesQuerable);
            var paginatedResult = moviesMapper.ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedResult;
        }
    }
}
