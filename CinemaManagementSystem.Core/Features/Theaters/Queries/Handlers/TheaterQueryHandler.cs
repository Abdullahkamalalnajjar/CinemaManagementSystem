using AutoMapper;
using CinemaManagementSystem.Core.Bases;
using CinemaManagementSystem.Core.Features.Theaters.Queries.Models;
using CinemaManagementSystem.Core.Features.Theaters.Queries.Results;
using CinemaManagementSystem.Core.Resources;
using CinemaManagementSystem.Service.Abstract;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CinemaManagementSystem.Core.Features.Theaters.Queries.Handlers
{
    public class TheaterQueryHandler : ResponseHandler,
        IRequestHandler<GetTheaterListQuery, Response<List<GetTheaterListResponse>>>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly ITheaterService _theaterService;
        private readonly IMapper _mapper;

        public TheaterQueryHandler(IStringLocalizer<SharedResources> localizer, ITheaterService theaterService, IMapper mapper) : base(localizer)
        {
            _localizer = localizer;
            _theaterService = theaterService;
            _mapper = mapper;
        }


        public async Task<Response<List<GetTheaterListResponse>>> Handle(GetTheaterListQuery request, CancellationToken cancellationToken)
        {
            var result = await _theaterService.GetTheaterListAsync();
            var resultMapper = _mapper.Map<List<GetTheaterListResponse>>(result);
            return Success(resultMapper);
        }
    }
}
