using CinemaManagementSystem.Core.Bases;
using CinemaManagementSystem.Core.Features.Users.Queries.Response;
using MediatR;

namespace CinemaManagementSystem.Core.Features.Users.Queries.Model;

public class GetUserByIdQuery : IRequest<Response<GetUserByIdResponse>>
{
    public string UserId { get; set; }
}