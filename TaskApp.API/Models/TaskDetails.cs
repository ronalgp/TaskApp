using TaskApp.API.Models.Base;

namespace TaskApp.API.Models;

public class TaskDetails : BaseEntities
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateOnly DueDate { get; set; }
    public string Status { get; set; } = "New";
    public int? UserId { get; set; }
    public string? TaskId { get; set; }
    public virtual User? User { get; set; }
}
