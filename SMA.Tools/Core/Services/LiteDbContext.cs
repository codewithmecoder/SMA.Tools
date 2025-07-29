using LiteDB;
using SMA.Tools.Core.Models;

namespace SMA.Tools.Core.Services;

public class LiteDbContext
{
    private readonly LiteDatabase _db = new("Filename=automation.db;Mode=Shared");

    public ILiteCollection<AccountModel> Accounts => _db.GetCollection<AccountModel>("accounts");
    public ILiteCollection<LogEntry> Logs => _db.GetCollection<LogEntry>("logs");
    public ILiteCollection<TaskModel> Tasks => _db.GetCollection<TaskModel>("tasks");
}