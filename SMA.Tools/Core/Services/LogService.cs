using SMA.Tools.Core.Interfaces;
using SMA.Tools.Core.Models;

namespace SMA.Tools.Core.Services;

public class LogService : ILogService
{
    private readonly List<LogEntry> _entries = [];
    public async Task<List<LogEntry>> GetLogsAsync()
    {
        return await Task.FromResult(_entries);
    }

    public Task LogAsync(LogEntry entry)
    {
        _entries.Add(entry);
        return Task.CompletedTask;
    }
}