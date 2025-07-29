using SMA.Tools.Core.Models;

namespace SMA.Tools.Core.Interfaces;

public interface ILogService
{
    Task<List<LogEntry>> GetLogsAsync();
    Task LogAsync(LogEntry entry);
}