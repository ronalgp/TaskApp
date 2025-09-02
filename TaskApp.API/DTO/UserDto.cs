namespace TaskApp.API.DTO;

public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public required string Email { get; set; }
    public string Roles { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
}
