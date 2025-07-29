using SMA.Tools.Core.Interfaces;

namespace SMA.Tools.Core.Services;

public class ProxyService : IProxyService
{
    public Task AssignProxyAsync(string accountId, string proxyAddress)
    {
        return Task.CompletedTask;
    }
}