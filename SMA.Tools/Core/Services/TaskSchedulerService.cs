using SMA.Tools.Core.Interfaces;
using SMA.Tools.Core.Models;

namespace SMA.Tools.Core.Services;

public class TaskSchedulerService(LiteDbContext db, ILogService log, IServiceProvider services) : ITaskScheduler
{
    public async Task RunScheduledTasksAsync()
    {
        var now = DateTime.UtcNow;
        var tasks = db.Tasks.Find(t => t.ScheduleAt <= now && !t.Executed).ToList();

        foreach (var task in tasks)
        {
            var service = task.Platform switch
            {
                "TikTok" => (IPlatformService)services.GetService(typeof(TikTokService))!,
                "Facebook" => (IPlatformService)services.GetService(typeof(FacebookService))!,
                "Instagram" => (IPlatformService)services.GetService(typeof(InstagramService))!,
                "YouTube" => (IPlatformService)services.GetService(typeof(YouTubeService))!,
                "X" => (IPlatformService)services.GetService(typeof(TwitterService))!,
                _ => null
            };

            if (service == null) continue;

            await service.PostAsync(task.AccountId, task.Content);
            task.Executed = true;
            db.Tasks.Update(task);
            await log.LogAsync(new LogEntry
            {
                AccountId = task.AccountId,
                Platform = task.Platform,
                Action = "ScheduledPost",
                Status = "Executed"
            });
        }
    }
}