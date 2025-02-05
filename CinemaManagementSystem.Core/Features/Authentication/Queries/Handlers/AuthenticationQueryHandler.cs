using CinemaManagementSystem.Core.Bases;
using CinemaManagementSystem.Core.Features.Authentication.Queries.Models;
using CinemaManagementSystem.Core.Resources;
using CinemaManagementSystem.Service.Abstract;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CinemaManagementSystem.Core.Features.Authentication.Queries.Handlers
{
    public class AuthenticationQueryHandler : ResponseHandler,
        IRequestHandler<ConfirmEmailQuery, Response<string>>
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationQueryHandler(IStringLocalizer<SharedResources> localizer, IAuthenticationService authenticationService) : base(localizer)
        {
            _authenticationService = authenticationService;
        }

        public async Task<Response<string>> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
        {
            var confirmEmail = await _authenticationService.ConfirmEmail(request.UserId, request.Code);
            if (confirmEmail == "ErrorWhenConfirmEmail")
                return BadRequest<string>("ErrorWhenConfirmEmail");
            return Success<string>("ConfirmEmailDone");
        }
    }
}
