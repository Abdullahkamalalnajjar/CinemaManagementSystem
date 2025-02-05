using CinemaManagementSystem.Core.Bases;
using CinemaManagementSystem.Core.Features.Emails.Commands.Models;
using CinemaManagementSystem.Core.Resources;
using CinemaManagementSystem.Service.Abstract;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CinemaManagementSystem.Core.Features.Emails.Commands.Handlers
{
    public class SendEmailCommandHandler : ResponseHandler,
        IRequestHandler<SendEmailCommand, Response<string>>
    {
        private readonly IEmailService _emailService;

        public SendEmailCommandHandler(IStringLocalizer<SharedResources> localizer, IEmailService emailService) : base(localizer)
        {
            _emailService = emailService;
        }

        public async Task<Response<string>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            var result = await _emailService.SendEmailAsync(request.To, request.Message);
            if (result == "Send") return Success<string>("Email sent successfully");
            return BadRequest<string>();
        }
    }
}
