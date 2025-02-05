using CinemaManagementSystem.Core.Bases;
using MediatR;

namespace CinemaManagementSystem.Core.Features.Emails.Commands.Models
{
    public class SendEmailCommand : IRequest<Response<string>>
    {
        public string To { get; set; }
        public string Message { get; set; }
    }
}
