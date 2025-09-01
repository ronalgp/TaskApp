namespace TaskApp.API.Models;

public class User
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = string.Empty;
    public required string Email { get; set; }
    public required byte[] HashPassword { get; set; }
    public required byte[] HashKey { get; set; }
    public string Roles { get; set; } = string.Empty;

    //Navigation Properties
    public TaskDetails TaskDetails { get; set; } = null!;
}
