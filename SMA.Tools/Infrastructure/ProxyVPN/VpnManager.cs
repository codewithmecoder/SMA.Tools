using System.Diagnostics;

namespace SMA.Tools.Infrastructure.ProxyVPN;

public class VpnManager
{
    public void ConnectVpn(string configPath)
    {
        var psi = new ProcessStartInfo("openvpn", $"--config \"{configPath}\"")
        {
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true
        };
        Process.Start(psi);
    }

    public void DisconnectVpn()
    {
        Process.Start("taskkill", "/IM openvpn.exe /F");
    }
}