namespace SMA.Tools.Core.Interfaces;

public interface IAccountService
{
    Task AddAccountAsync(string platform, string accountId);
    Task<List<string>> GetAccountsAsync(string platform);
}