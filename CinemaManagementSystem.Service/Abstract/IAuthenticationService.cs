using CinemaManagementSystem.Data.Entities.Identity;
using CinemaManagementSystem.Data.Helpers;

namespace CinemaManagementSystem.Service.Abstract;

public interface IAuthenticationService
{
    public Task<JwtAuthResult> GenerateTokenAsync(AppUser user);
}