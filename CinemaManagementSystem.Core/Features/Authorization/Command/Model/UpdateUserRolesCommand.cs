using CinemaManagementSystem.Core.Bases;
using MediatR;
using SchoolProject.Data.DTOs;

namespace CinemaManagementSystem.Core.Features.Authorization.Command.Model;

public class UpdateUserRolesCommand : IRequest<Response<string>>
{
    public string UserId { get; set; }
    public List<UserRoles> Roles { get; set; }
}
