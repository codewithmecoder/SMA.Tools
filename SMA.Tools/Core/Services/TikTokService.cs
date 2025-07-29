using SMA.Tools.Core.Interfaces;

namespace SMA.Tools.Core.Services;

public class TikTokService(ILdPlayerController ld) : IPlatformService
{
    public async Task LoginAsync(string accountId)
    {
        var deviceId = ld.GetDeviceIdForInstance(accountId);
        ld.SendTap(deviceId, 200, 300);
        await Task.Delay(500);
        ld.SendText(deviceId, "tiktokuser");
        ld.SendText(deviceId, "tiktokpass");
        ld.SendTap(deviceId, 500, 900);
    }

    public async Task PostAsync(string accountId, string content)
    {
        var deviceId = ld.GetDeviceIdForInstance(accountId);
        ld.SendTap(deviceId, 500, 1600);
        await Task.Delay(500);
        ld.SendText(deviceId, content);
        ld.SendTap(deviceId, 600, 1700);
    }

    public async Task LikePostAsync(string accountId, string postId)
    {
        var deviceId = ld.GetDeviceIdForInstance(accountId);
        ld.SendTap(deviceId, 700, 1200);
        await Task.Delay(300);
    }
}