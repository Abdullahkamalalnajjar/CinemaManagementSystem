using CinemaManagementSystem.Data.Entities.Identity;

namespace CinemaManagementSystem.Service.Abstract;

public interface IAppUserService
{
    public Task<bool> IsEmailExistExcludeSelf(string id, string email);
    public Task<string> AddUserAsync(AppUser user, string password);

}