using SMA.Tools.Core.Interfaces;

namespace SMA.Tools.Core.Services;

public class TwitterService(ILdPlayerController ld) : IPlatformService
{
    public async Task LoginAsync(string accountId)
    {
        var deviceId = ld.GetDeviceIdForInstance(accountId);
        ld.SendTap(deviceId, 270, 380);
        await Task.Delay(500);
        ld.SendText(deviceId, "xuser");
        await Task.Delay(500);
        ld.SendText(deviceId, "xpassword");
        ld.SendTap(deviceId, 500, 900);
    }

    public async Task PostAsync(string accountId, string content)
    {
        var deviceId = ld.GetDeviceIdForInstance(accountId);
        ld.SendTap(deviceId, 500, 1750);
        await Task.Delay(500);
        ld.SendText(deviceId, content);
        ld.SendTap(deviceId, 600, 1650);
    }

    public async Task LikePostAsync(string accountId, string postId)
    {
        var deviceId = ld.GetDeviceIdForInstance(accountId);
        ld.SendTap(deviceId, 700, 1180);
        await Task.Delay(300);
    }
}