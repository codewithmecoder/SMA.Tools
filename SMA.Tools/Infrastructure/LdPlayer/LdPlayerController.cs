using SMA.Tools.Core.Interfaces;
using System.Diagnostics;

namespace SMA.Tools.Infrastructure.LdPlayer;

public class LdPlayerController : ILdPlayerController
{
    public void LaunchInstance(string instanceName)
    {
        Process.Start("ldconsole.exe", $"launch --name {instanceName}");
    }

    public void SendTap(string deviceId, int x, int y)
    {
        Process.Start("adb", $"-s {deviceId} shell input tap {x} {y}");
    }

    public void SendText(string deviceId, string text)
    {
        var escaped = text.Replace(" ", "%s");
        Process.Start("adb", $"-s {deviceId} shell input text {escaped}");
    }

    public string GetDeviceIdForInstance(string instanceName) => instanceName; // Simplified
}