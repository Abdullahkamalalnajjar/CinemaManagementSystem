using CinemaManagementSystem.Data.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagementSystem.infrustructure.Seeder;

public static class UserSeeder
{

    public static async Task SeedAsync(UserManager<AppUser> userManager)
    {
        var users = await userManager.Users.CountAsync();
        if (users <= 0)
        {
            var defaultUser = new AppUser
            {
                UserName = "admin",
                FullName = "Admin School Project",
                Email = "admin@admin.com",
                EmailConfirmed = true,
                Password = "Admin@123",
                PhoneNumber = "123456789",
            };
            await userManager.CreateAsync(defaultUser, "Admin@123");
            await userManager.AddToRoleAsync(defaultUser, "Admin");
        }

    }
}