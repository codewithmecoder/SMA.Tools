namespace SMA.Tools.Core.Interfaces;

public interface ILdPlayerController
{
    void LaunchInstance(string instanceName);
    void SendTap(string deviceId, int x, int y);
    void SendText(string deviceId, string text);
    string GetDeviceIdForInstance(string instanceName);
}