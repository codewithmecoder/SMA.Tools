using SMA.Tools.Core.Interfaces;

namespace SMA.Tools.Core.Services;

public class InstagramService(ILdPlayerController ld) : IPlatformService
{
    public async Task LoginAsync(string accountId)
    {
        var deviceId = ld.GetDeviceIdForInstance(accountId);
        ld.SendTap(deviceId, 300, 400);
        await Task.Delay(500);
        ld.SendText(deviceId, "iguser");
        await Task.Delay(500);
        ld.SendText(deviceId, "igpassword");
        ld.SendTap(deviceId, 500, 950);
    }

    public async Task PostAsync(string accountId, string content)
    {
        var deviceId = ld.GetDeviceIdForInstance(accountId);
        ld.SendTap(deviceId, 550, 1800);
        await Task.Delay(500);
        ld.SendText(deviceId, content);
        ld.SendTap(deviceId, 600, 1700);
    }

    public async Task LikePostAsync(string accountId, string postId)
    {
        var deviceId = ld.GetDeviceIdForInstance(accountId);
        ld.SendTap(deviceId, 720, 1150);
        await Task.Delay(300);
    }
}