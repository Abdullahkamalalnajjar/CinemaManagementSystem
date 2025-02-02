using AutoMapper;
using CinemaManagementSystem.Core.Bases;
using CinemaManagementSystem.Core.Features.Theaters.Commands.Models;
using CinemaManagementSystem.Core.Resources;
using CinemaManagementSystem.Data.Entities;
using CinemaManagementSystem.Service.Abstract;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CinemaManagementSystem.Core.Features.Theaters.Commands.Handlers
{
    public class TheaterCommandHandler : ResponseHandler,
        IRequestHandler<AddTheaterCommand, Response<string>>,
        IRequestHandler<EditTheaterCommand, Response<string>>,
        IRequestHandler<DeleteTheaterCommand, Response<string>>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly ITheaterService _theaterService;
        private readonly IMapper _mapper;

        public TheaterCommandHandler(IStringLocalizer<SharedResources> localizer, ITheaterService theaterService, IMapper mapper) : base(localizer)
        {
            _localizer = localizer;
            _theaterService = theaterService;
            _mapper = mapper;
        }
        public async Task<Response<string>> Handle(AddTheaterCommand request, CancellationToken cancellationToken)
        {
            var theater = _mapper.Map<Theater>(request);
            var result = await _theaterService.AddTheaterAsync(theater);
            if (result == "Added") return Created("تم إضافه القاعه بنجاح");
            return BadRequest<string>("حدث خطأ أثناء إضافه القاعه");
        }

        public async Task<Response<string>> Handle(EditTheaterCommand request, CancellationToken cancellationToken)
        {
            // Check if the theater exists
            var result = await _theaterService.GetTheaterByIdAsync(request.Id);
            if (result is null) return NotFound<string>("القاعه غير موجوده");
            var theater = _mapper.Map<Theater>(request);
            var updateResult = await _theaterService.EditTheaterAsync(theater);
            if (updateResult == "Updated") return Updated("تم تعديل القاعه بنجاح");
            return BadRequest<string>("حدث خطأ أثناء تعديل القاعه");
        }

        public async Task<Response<string>> Handle(DeleteTheaterCommand request, CancellationToken cancellationToken)
        {
            // Check if the theater exists
            var result = await _theaterService.GetTheaterByIdAsync(request.Id);
            if (result is null) return NotFound<string>("القاعه غير موجوده");
            var deleteResult = await _theaterService.DeleteTheaterAsync(result);
            if (deleteResult == "Deleted") return Deleted<string>();
            return BadRequest<string>("حدث خطأ أثناء حذف القاعه");
        }
    }
}
