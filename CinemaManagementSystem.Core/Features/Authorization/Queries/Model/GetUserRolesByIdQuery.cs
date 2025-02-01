using CinemaManagementSystem.Core.Bases;
using MediatR;
using SchoolProject.Data.DTOs;

namespace CinemaManagementSystem.Core.Features.Authorization.Queries.Model;

public class GetUserRolesByIdQuery(string userId) : IRequest<Response<GetUserRolesResponse>>
{
    public string UserId { get; set; } = userId;
}