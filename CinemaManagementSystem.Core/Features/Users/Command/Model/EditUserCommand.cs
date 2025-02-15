using CinemaManagementSystem.Core.Bases;
using MediatR;

namespace CinemaManagementSystem.Core.Features.Users.Command.Model;

public class EditUserCommand : IRequest<Response<string>>
{
    public string Id { get; set; }
    public string Username { get; set; }
    public string PhoneNumber { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string? Address { get; set; }
    public string? Country { get; set; }
}