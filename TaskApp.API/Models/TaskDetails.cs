namespace TaskApp.API.Models;

public class TaskDetails
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateOnly DueDate { get; set; }
    public string Status { get; set; } = "Pending";
}
