using CinemaManagementSystem.Core.Bases;
using CinemaManagementSystem.Data.DTOs;
using MediatR;

namespace CinemaManagementSystem.Core.Features.Authorization.Queries.Model;

public class GetUserClaimsByIdQuery(string userId) : IRequest<Response<GetUserClaimsResponse>>
{
    public string UserId { get; set; } = userId;
}