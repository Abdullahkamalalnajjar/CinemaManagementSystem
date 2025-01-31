using System.Security.Claims;

namespace CinemaManagementSystem.Data.Helpers;

public static class ClaimsStore
{
    public static List<Claim> Claims = new()
    {
     new Claim("Create Movie", "false"),
     new Claim("Edit Movie", "false"),
     new Claim("Delete Movie", "false")
    };
}