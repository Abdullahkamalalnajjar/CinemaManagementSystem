using AutoMapper;
using CinemaManagementSystem.Core.Bases;
using CinemaManagementSystem.Core.Features.Showtimes.Queries.Models;
using CinemaManagementSystem.Core.Features.Showtimes.Queries.Results;
using CinemaManagementSystem.Core.Resources;
using CinemaManagementSystem.Service.Abstract;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CinemaManagementSystem.Core.Features.Showtimes.Queries.Handlers
{
    public class ShowtimeQueryHandler : ResponseHandler,
        IRequestHandler<GetShowtimeByIdQuery, Response<GetShowtimeByIdResponse>>,
        IRequestHandler<GetShowtimeListQuery, Response<List<GetShowtimeByIdResponse>>>
    {
        private readonly IShowtimeService _showtimeService;
        private readonly IMapper _mapper;

        public ShowtimeQueryHandler(IStringLocalizer<SharedResources> localizer, IShowtimeService showtimeService, IMapper mapper) : base(localizer)
        {
            _showtimeService = showtimeService;
            _mapper = mapper;
        }

        public async Task<Response<GetShowtimeByIdResponse>> Handle(GetShowtimeByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _showtimeService.GetShowtimeByIdAsync(request.Id);
            if (result == null) return NotFound<GetShowtimeByIdResponse>("Showtime Not Found");
            var response = _mapper.Map<GetShowtimeByIdResponse>(result);
            return Success(response);
        }

        public async Task<Response<List<GetShowtimeByIdResponse>>> Handle(GetShowtimeListQuery request, CancellationToken cancellationToken)
        {
            var result = await _showtimeService.GetShowtimeListAsync();
            var response = _mapper.Map<List<GetShowtimeByIdResponse>>(result);
            return Success(response);
        }
    }

}
