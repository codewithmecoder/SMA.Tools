using Microsoft.Extensions.Hosting;
using Timer = System.Timers.Timer;
using SMA.Tools.Core.Interfaces;

namespace SMA.Tools.Core.Services;

public class BackgroundScheduler(ITaskScheduler scheduler) : IHostedService
{
    private Timer? _timer;
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(60000); // 1-minute interval
        _timer.Elapsed += async (s, e) => await scheduler.RunScheduledTasksAsync();
        _timer.Start();
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Stop();
        return Task.CompletedTask;
    }
}