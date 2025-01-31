using CinemaManagementSystem.Core.Features.Users.Queries.Response;
using CinemaManagementSystem.Data.Entities.Identity;

namespace CinemaManagementSystem.Core.Mapping.Users;

public partial class UserProfile
{
    public void Mapping_GetUserByIdQuery()
    {
        CreateMap<AppUser, GetUserByIdResponse>();
    }
}