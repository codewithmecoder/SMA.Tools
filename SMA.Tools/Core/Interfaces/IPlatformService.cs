namespace SMA.Tools.Core.Interfaces;

public interface IPlatformService
{
    Task LoginAsync(string accountId);
    Task PostAsync(string accountId, string content);
    Task LikePostAsync(string accountId, string postId);
}