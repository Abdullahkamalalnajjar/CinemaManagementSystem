using CinemaManagementSystem.Core.Bases;
using CinemaManagementSystem.Data.DTOs;
using MediatR;

namespace CinemaManagementSystem.Core.Features.Authorization.Queries.Model
{
    public class GetClaimsListQuery : IRequest<Response<List<GetClaimsResponse>>>
    {

    }
}
