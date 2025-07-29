using SMA.Tools.Core.Interfaces;

namespace SMA.Tools.Core.Services;

public class FacebookService(ILdPlayerController ld) : IPlatformService
{
    public async Task LoginAsync(string accountId)
    {
        var deviceId = ld.GetDeviceIdForInstance(accountId);
        ld.SendTap(deviceId, 300, 350); // Tap email
        await Task.Delay(400);
        ld.SendText(deviceId, "fbuser");
        ld.SendTap(deviceId, 300, 500); // Tap password
        await Task.Delay(400);
        ld.SendText(deviceId, "fbpassword");
        ld.SendTap(deviceId, 500, 900); // Tap login
    }

    public async Task PostAsync(string accountId, string content)
    {
        var deviceId = ld.GetDeviceIdForInstance(accountId);
        ld.SendTap(deviceId, 400, 1800); // Tap create post
        await Task.Delay(1000);
        ld.SendText(deviceId, content);
        ld.SendTap(deviceId, 600, 1700); // Tap post
    }

    public async Task LikePostAsync(string accountId, string postId)
    {
        var deviceId = ld.GetDeviceIdForInstance(accountId);
        ld.SendTap(deviceId, 700, 1200); // Like button location
        await Task.Delay(300);
    }
}