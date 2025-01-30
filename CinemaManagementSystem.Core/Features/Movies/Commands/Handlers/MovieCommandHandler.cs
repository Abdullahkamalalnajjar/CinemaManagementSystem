using AutoMapper;
using CinemaManagementSystem.Core.Bases;
using CinemaManagementSystem.Core.Features.Movies.Commands.Models;
using CinemaManagementSystem.Core.Features.Movies.Commands.Results;
using CinemaManagementSystem.Core.Resources;
using CinemaManagementSystem.Data.Entities;
using CinemaManagementSystem.Service.Abstract;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CinemaManagementSystem.Core.Features.Movies.Commands.Handlers
{
    public class MovieCommandHandler : ResponseHandler,
        IRequestHandler<AddMovieCommand, Response<AddMovieCommandResponse>>,
        IRequestHandler<EditMovieCommand, Response<string>>,
        IRequestHandler<DeleteMovieCommand, Response<string>>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MovieCommandHandler(IStringLocalizer<SharedResources> localizer, IMovieService movieService, IMapper mapper) : base(localizer)
        {
            _localizer = localizer;
            _movieService = movieService;
            _mapper = mapper;
        }

        public async Task<Response<AddMovieCommandResponse>> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = _mapper.Map<Movie>(request);
            var result = await _movieService.AddMovieAsync(movie);
            if (result is null) return BadRequest<AddMovieCommandResponse>();
            var resultMapper = _mapper.Map<AddMovieCommandResponse>(result);
            return Success(resultMapper);
        }

        public async Task<Response<string>> Handle(EditMovieCommand request, CancellationToken cancellationToken)
        {
            var movieMapper = _mapper.Map<Movie>(request);
            var editMoive = await _movieService.EditMovieAsync(movieMapper);
            if (editMoive == "Updated") return Updated<string>(_localizer[SharedResourcesKeys.Updated]);

            return BadRequest<string>(_localizer[SharedResourcesKeys.Updated]);
        }

        public async Task<Response<string>> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var checkMovie = await _movieService.GetMovieByIdAsync(request.Id);
            if (checkMovie is null) return NotFound<string>();
            var result = await _movieService.DeleteMovieByIdAsync(request.Id);
            if (result == "Deleted") return Deleted<string>();
            return BadRequest<string>();
        }
    }
}
