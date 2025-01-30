using CinemaManagementSystem.Core.Features.Theaters.Commands.Models;
using CinemaManagementSystem.Service.Abstract;
using FluentValidation;

namespace CinemaManagementSystem.Core.Features.Theaters.Commands.Validators
{
    public class AddTheaterCommandValidator : AbstractValidator<AddTheaterCommand>
    {
        private readonly ITheaterService _theaterService;

        public AddTheaterCommandValidator(ITheaterService theaterService)
        {
            _theaterService = theaterService;
            ValidateScreenNumber();
            CustomValidateScreenNumber();
        }
        public void ValidateScreenNumber()
        {
            RuleFor(x => x.ScreenNumber).NotEmpty().WithMessage("ScreenNumber is required");
        }
        public void CustomValidateScreenNumber()
        {
            RuleFor(x => x.ScreenNumber)
                .MustAsync(async (key, CancellationToken) => !await _theaterService.IsTheaterExist(key))
                .WithMessage("ScreenNumber Already Exist");
            RuleFor(x => x.ScreenNumber).MaximumLength(50).WithMessage("ScreenNumber must be less than 50 characters");
            RuleFor(x => x.TotalSeats).Must(x => x > 0).WithMessage("TotalSeats must be greater than 0");
        }
    }
}
