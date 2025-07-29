using SMA.Tools.Core.Interfaces;

namespace SMA.Tools.Core.Services;

public class YouTubeService(ILdPlayerController ld) : IPlatformService
{
    public async Task LoginAsync(string accountId)
    {
        var deviceId = ld.GetDeviceIdForInstance(accountId);
        ld.SendTap(deviceId, 250, 350);
        await Task.Delay(500);
        ld.SendText(deviceId, "ytuser");
        await Task.Delay(500);
        ld.SendText(deviceId, "ytpassword");
        ld.SendTap(deviceId, 500, 950);
    }

    public async Task PostAsync(string accountId, string content)
    {
        var deviceId = ld.GetDeviceIdForInstance(accountId);
        ld.SendTap(deviceId, 520, 1800);
        await Task.Delay(1000);
        ld.SendText(deviceId, content);
        ld.SendTap(deviceId, 580, 1650);
    }

    public async Task LikePostAsync(string accountId, string postId)
    {
        var deviceId = ld.GetDeviceIdForInstance(accountId);
        ld.SendTap(deviceId, 720, 1100);
        await Task.Delay(300);
    }
}