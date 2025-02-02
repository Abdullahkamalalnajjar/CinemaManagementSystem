using System.Security.Claims;

namespace CinemaManagementSystem.Data.Helpers;

public static class ClaimsStore
{
    public static List<Claim> Claims = new()
    {
     new Claim("Create Movie", "false"),
     new Claim("Edit Movie", "false"),
     new Claim("Delete Movie", "false"),
     new Claim("Create Showtime", "false"),
     new Claim("Edit Showtime", "false"),
     new Claim("Delete Showtime", "false"),
     new Claim("Create Reservation", "false"),
     new Claim("Edit Reservation", "false"),
     new Claim("Delete Reservation", "false"),
     new Claim("Create Theater", "false"),
     new Claim("Edit Theater", "false"),
     new Claim("Delete Theater", "false"),
    };
}