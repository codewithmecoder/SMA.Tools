using SMA.Tools.Core.Interfaces;
using SMA.Tools.Core.Models;

namespace SMA.Tools.Core.Services;

public class AccountManager(LiteDbContext db) : IAccountService
{
    public Task AddAccountAsync(string platform, string accountId)
    {
        db.Accounts.Insert(new AccountModel { Platform = platform, Id = accountId });
        return Task.CompletedTask;
    }

    public Task<List<string>> GetAccountsAsync(string platform)
    {
        var accounts = db.Accounts.Find(a => a.Platform == platform).Select(a => a.Id).ToList();
        return Task.FromResult(accounts);
    }
}