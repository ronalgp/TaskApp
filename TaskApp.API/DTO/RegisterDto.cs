using System.ComponentModel.DataAnnotations;

namespace TaskApp.API.DTO;

public class RegisterDto
{
    public string Name { get; set; } = string.Empty;
    [EmailAddress]
    public required string Email { get; set; }
    [MinLength(4)]
    public required string Password { get; set; }
    public string Roles { get; set; } = "Member";
}
