namespace SMA.Tools.Core.Models;

public class TaskModel
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string AccountId { get; set; } = string.Empty;
    public string Platform { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime ScheduleAt { get; set; }
    public bool Executed { get; set; } = false;
}