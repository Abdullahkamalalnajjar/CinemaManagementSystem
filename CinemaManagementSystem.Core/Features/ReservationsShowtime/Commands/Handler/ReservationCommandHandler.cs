using AutoMapper;
using CinemaManagementSystem.Core.Bases;
using CinemaManagementSystem.Core.Features.ReservationsShowtime.Commands.Models;
using CinemaManagementSystem.Core.Resources;
using CinemaManagementSystem.Data.Entities;
using CinemaManagementSystem.Service.Abstract;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CinemaManagementSystem.Core.Features.ReservationsShowtime.Commands.Handler
{
    public class ReservationCommandHandler : ResponseHandler,
        IRequestHandler<CreateReservationCommand, Response<string>>,
        IRequestHandler<EditReservationCommand, Response<string>>,
        IRequestHandler<DeleteReservationCommand, Response<string>>
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;

        public ReservationCommandHandler(IReservationService reservationService, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservationMapper = _mapper.Map<Reservation>(request);
            var result = await _reservationService.CreateReservationAsync(reservationMapper);
            if (result == "Added") return Success<string>(result);
            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditReservationCommand request, CancellationToken cancellationToken)
        {
            var reservationMapper = _mapper.Map<Reservation>(request);
            var result = await _reservationService.EditReservationAsync(reservationMapper);
            if (result == "Updated") return Updated<string>(result);
            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationService.GetReservationByIdAsync(request.Id);
            if (reservation is null) return NotFound<string>();
            var result = await _reservationService.DeleteReservationAsync(reservation);
            if (result == "Deleted") return Deleted<string>();
            return BadRequest<string>();
        }
    }
}
