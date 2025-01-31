namespace CinemaManagementSystem.Core.Features.Users.Queries.Response;

public class GetUserByIdResponse
{
    public string Username { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string? Address { get; set; }
    public string? Country { get; set; }
}