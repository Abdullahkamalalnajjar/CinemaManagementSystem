using AutoMapper;
using CinemaManagementSystem.Core.Bases;
using CinemaManagementSystem.Core.Features.Showtimes.Commands.Models;
using CinemaManagementSystem.Core.Resources;
using CinemaManagementSystem.Data.Entities;
using CinemaManagementSystem.Service.Abstract;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CinemaManagementSystem.Core.Features.Showtimes.Commands.Handlers
{
    public class ShowtimeCommandHandler : ResponseHandler,
        IRequestHandler<AddShowtimeCommand, Response<string>>,
        IRequestHandler<EditShowtimeCommand, Response<string>>,
        IRequestHandler<DeleteShowtimeCommand, Response<string>>
    {
        private readonly IShowtimeService _showtimeService;
        private readonly IMapper _mapper;

        public ShowtimeCommandHandler(IShowtimeService showtimeService, IStringLocalizer<SharedResources> localizer, IMapper mapper) : base(localizer)
        {
            _showtimeService = showtimeService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddShowtimeCommand request, CancellationToken cancellationToken)
        {
            // Make mapping from AddShowtimeCommand to Showtime
            var showtime = _mapper.Map<Showtime>(request);
            // Call AddShowtimeAsync method from IShowtimeService
            var result = await _showtimeService.AddShowtimeAsync(showtime);
            if (result == "Added") return Created("Showtime Add Successfully");
            return BadRequest<string>("Showtime Not Added");
        }

        public async Task<Response<string>> Handle(EditShowtimeCommand request, CancellationToken cancellationToken)
        {
            var showtime = _mapper.Map<Showtime>(request);
            var result = await _showtimeService.EditShowtimeAsync(showtime);
            if (result == "Updated") return Updated("Showtime Updated Successfully");
            return BadRequest<string>("Showtime Not Updated");
        }

        public async Task<Response<string>> Handle(DeleteShowtimeCommand request, CancellationToken cancellationToken)
        {
            var showtime = await _showtimeService.GetShowtimeByIdAsync(request.Id);
            if (showtime is null) return NotFound<string>("Showtime Not Found");
            var result = await _showtimeService.DeleteShowtimeAsync(showtime);
            if (result == "Deleted") return Deleted<string>();
            return BadRequest<string>("Showtime Not Deleted");
        }
    }
}
