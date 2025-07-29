namespace SMA.Tools.Core.Models;

public class LogEntry
{
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public string AccountId { get; set; } = string.Empty;
    public string Platform { get; set; } = string.Empty;
    public string Action { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}