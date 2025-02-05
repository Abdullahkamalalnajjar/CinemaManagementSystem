using CinemaManagementSystem.Core.Bases;
using CinemaManagementSystem.Data.Helpers;
using MediatR;

namespace CinemaManagementSystem.Core.Features.Authentication.Commands.Model;

public class SignInCommand : IRequest<Response<JwtAuthResult>>
{
    public string Username { get; set; }
    public string Password { get; set; }
}