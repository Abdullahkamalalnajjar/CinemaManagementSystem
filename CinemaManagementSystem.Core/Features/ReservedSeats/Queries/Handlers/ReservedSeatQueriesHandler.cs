using AutoMapper;
using CinemaManagementSystem.Core.Bases;
using CinemaManagementSystem.Core.Features.ReservedSeats.Queries.Models;
using CinemaManagementSystem.Core.Features.ReservedSeats.Queries.Results;
using CinemaManagementSystem.Core.Resources;
using CinemaManagementSystem.Service.Abstract;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CinemaManagementSystem.Core.Features.ReservedSeats.Queries.Handlers
{
    public class ReservedSeatQueriesHandler : ResponseHandler,
        IRequestHandler<GetReservedSeatListQuery, Response<List<GetReservedSeatListResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly IReservedSeatService _reservedSeatService;

        public ReservedSeatQueriesHandler(IStringLocalizer<SharedResources> localizer, IMapper mapper, IReservedSeatService reservedSeatService) : base(localizer)
        {
            _mapper = mapper;
            _reservedSeatService = reservedSeatService;
        }

        public async Task<Response<List<GetReservedSeatListResponse>>> Handle(GetReservedSeatListQuery request, CancellationToken cancellationToken)
        {
            var reservedSeats = await _reservedSeatService.GetReservedSeatListAsync();
            var response = _mapper.Map<List<GetReservedSeatListResponse>>(reservedSeats);
            return Success(response);
        }
    }
}
