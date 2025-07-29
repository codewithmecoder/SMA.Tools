namespace SMA.Tools.Core.Interfaces;

public interface IProxyService
{
    Task AssignProxyAsync(string accountId, string proxyAddress);
}