using CinemaManagementSystem.Core.Bases;
using CinemaManagementSystem.Data.DTOs;
using MediatR;

namespace CinemaManagementSystem.Core.Features.Authorization.Command.Model
{
    public class UpdateUserClaimsCommand : IRequest<Response<string>>
    {
        public string UserId { get; set; }
        public List<UserClaims> UserClaims { get; set; }
    }
}
