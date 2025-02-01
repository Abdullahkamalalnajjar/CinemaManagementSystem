using CinemaManagementSystem.Data.DTOs;
using CinemaManagementSystem.Data.Entities.Identity;
using SchoolProject.Data.DTOs;

namespace CinemaManagementSystem.Service.Abstract;

public interface IAuthorizationService
{
    public Task<string> AddRoleAsync(string roleName);
    public Task<bool> IsExistRoleByRoleName(string roleName);
    public Task<bool> IsExistRoleByRoleId(string roleId);
    public Task<List<GetRolesResponse>> GetRolesListAsync();
    public List<GetClaimsResponse> GetClaimsListAsync();
    public Task<GetUserRolesResponse> GetUserRolesDataAsync(AppUser user);
    public Task<GetUserClaimsResponse> GetUserClaimsDataAsync(AppUser user);
    public Task<string> UpdateUserRolesAsync(GetUserRolesResponse response);
    public Task<string> UpdateUserClaimsAsync(UpdateUserClaimsRequest request);
}