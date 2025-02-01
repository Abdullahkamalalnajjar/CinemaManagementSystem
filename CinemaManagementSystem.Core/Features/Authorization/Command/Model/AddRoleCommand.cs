using CinemaManagementSystem.Core.Bases;
using MediatR;

namespace CinemaManagementSystem.Core.Features.Authorization.Command.Model;

public class AddRoleCommand : IRequest<Response<string>>
{
    public string RoleName { get; set; }
}