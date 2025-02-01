using CinemaManagementSystem.Core.Bases;
using CinemaManagementSystem.Data.DTOs;
using MediatR;

namespace CinemaManagementSystem.Core.Features.Authorization.Queries.Model
{
    public class GetRolesListQuery : IRequest<Response<List<GetRolesResponse>>>
    {

    }
}
