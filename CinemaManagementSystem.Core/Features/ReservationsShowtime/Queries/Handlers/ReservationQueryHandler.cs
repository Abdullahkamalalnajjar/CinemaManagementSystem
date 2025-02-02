using AutoMapper;
using CinemaManagementSystem.Core.Bases;
using CinemaManagementSystem.Core.Features.ReservationsShowtime.Queries.Models;
using CinemaManagementSystem.Core.Features.ReservationsShowtime.Queries.Results;
using CinemaManagementSystem.Core.Resources;
using CinemaManagementSystem.Service.Abstract;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CinemaManagementSystem.Core.Features.ReservationsShowtime.Queries.Handlers
{
    public class ReservationQueryHandler : ResponseHandler,
        IRequestHandler<GetReservationListQuery, Response<List<GetReservationListResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly IReservationService _reservationService;


        public ReservationQueryHandler(IStringLocalizer<SharedResources> localizer, IMapper mapper, IReservationService reservationService) : base(localizer)
        {
            _mapper = mapper;
            _reservationService = reservationService;
        }

        public async Task<Response<List<GetReservationListResponse>>> Handle(GetReservationListQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _reservationService.GetReservationListAsync();
            var reservationMapper = _mapper.Map<List<GetReservationListResponse>>(reservations);
            var response = Success<List<GetReservationListResponse>>(reservationMapper);
            return response;
        }
    }
}
