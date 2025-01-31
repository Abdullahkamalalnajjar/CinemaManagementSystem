using CinemaManagementSystem.Core.Features.Users.Command.Model;
using CinemaManagementSystem.Data.Entities.Identity;

namespace CinemaManagementSystem.Core.Mapping.Users;

public partial class UserProfile
{
    public void Mapping_EditUserCommandMapping()
    {
        CreateMap<EditUserCommand, AppUser>()
            .ForMember(i => i.Id, opt => opt.Ignore());
    }
}