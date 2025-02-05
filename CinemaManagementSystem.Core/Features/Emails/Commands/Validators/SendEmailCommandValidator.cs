using CinemaManagementSystem.Core.Features.Emails.Commands.Models;
using FluentValidation;

namespace CinemaManagementSystem.Core.Features.Emails.Commands.Validators
{
    public class SendEmailCommandValidator : AbstractValidator<SendEmailCommand>
    {

        public SendEmailCommandValidator()
        {

            ApplySendEmailValidations();
        }
        public void ApplySendEmailValidations()
        {
            RuleFor(x => x.To)
                .NotEmpty().WithMessage("To is required")
                .EmailAddress().WithMessage("To must be a valid email address");
            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("Message is required")
                .MaximumLength(100).WithMessage("Subject must not exceed 100 characters");

        }
    }
}
