using CinemaManagementSystem.Core.Bases;
using MediatR;

namespace CinemaManagementSystem.Core.Features.Users.Command.Model;

public class DeleteUserCommand : IRequest<Response<string>>
{
    public string Id { get; set; }
}