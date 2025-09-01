using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TaskApp.API.Models.Base;

namespace TaskApp.API.Models;

public class TaskDetails : BaseEntities
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateOnly DueDate { get; set; }
    public string Status { get; set; } = "New";

    //Navigation properties
    [JsonIgnore]
    [ForeignKey(nameof(Id))]
    public User User { get; set; } = null!;
}
