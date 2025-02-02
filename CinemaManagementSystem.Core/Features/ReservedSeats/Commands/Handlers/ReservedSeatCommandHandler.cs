using AutoMapper;
using CinemaManagementSystem.Core.Bases;
using CinemaManagementSystem.Core.Features.ReservedSeats.Commands.Models;
using CinemaManagementSystem.Core.Resources;
using CinemaManagementSystem.Data.Entities;
using CinemaManagementSystem.Service.Abstract;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CinemaManagementSystem.Core.Features.ReservedSeats.Commands.Handlers
{
    public class ReservedSeatCommandHandler : ResponseHandler,
        IRequestHandler<CreateReservedSeatCommand, Response<string>>,
        IRequestHandler<EditReservedSeatCommand, Response<string>>,
        IRequestHandler<DeleteReservedSeatCommand, Response<string>>
    {
        private readonly IReservedSeatService _reservedSeatService;
        private readonly IMapper _mapper;

        public ReservedSeatCommandHandler(IStringLocalizer<SharedResources> localizer, IReservedSeatService reservedSeatService, IMapper mapper) : base(localizer)
        {
            _reservedSeatService = reservedSeatService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(CreateReservedSeatCommand request, CancellationToken cancellationToken)
        {
            // Make Mapper to map CreateReservedSeatCommand to ReservedSeat
            var reservedSeat = _mapper.Map<ReservedSeat>(request);
            // Add the new ReservedSeat to the database
            var result = await _reservedSeatService.CreateReservedSeatAsync(reservedSeat);
            if (result == "Added") return Created<string>(result);
            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditReservedSeatCommand request, CancellationToken cancellationToken)
        {
            var editReservedSeat = _mapper.Map<ReservedSeat>(request);
            var result = await _reservedSeatService.EditReservedSeatAsync(editReservedSeat);
            if (result == "Updated") return Updated<string>("تم تحديث مقاعد الحجز بنجاح");
            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteReservedSeatCommand request, CancellationToken cancellationToken)
        {
            var reservesSeat = await _reservedSeatService.GetReservedSeatByIdAsync(request.Id);
            if (reservesSeat is null) return NotFound<string>();
            var result = await _reservedSeatService.DeleteReservedSeatAsync(reservesSeat);
            if (result == "Deleted") return Deleted<string>("تم حذف مقاعد الحجز بنجاح");
            return BadRequest<string>();
        }
    }
}
