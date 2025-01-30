using CinemaManagementSystem.Core.Features.Theaters.Commands.Models;
using CinemaManagementSystem.Service.Abstract;
using FluentValidation;

namespace CinemaManagementSystem.Core.Features.Theaters.Commands.Validators
{
    public class EditTheaterCommandValidator : AbstractValidator<EditTheaterCommand>
    {
        private readonly ITheaterService _theaterService;

        public EditTheaterCommandValidator(ITheaterService theaterService)
        {
            _theaterService = theaterService;
            ValidateScreenNumber();
            CustomValidateScreenNumber();
        }

        public void ValidateScreenNumber()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(x => x.ScreenNumber).NotEmpty().WithMessage("Screen number is required");
            RuleFor(x => x.TotalSeats).GreaterThan(0).WithMessage("Total seats must be greater than 0");

        }

        public void CustomValidateScreenNumber()
        {
            RuleFor(x => x.ScreenNumber).MaximumLength(50).WithMessage("Screen number must be less than 50 characters");

            RuleFor(x => x.ScreenNumber)
                .MustAsync(async (model, key, CancellationToken) => !await _theaterService.IsScreenNumberExistExcludeSelf(model.Id, key))
                .WithMessage("Screen Number Already Exist");
        }
    }

}
