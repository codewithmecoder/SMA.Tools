namespace SMA.Tools.Core.Interfaces;

public interface ITaskScheduler
{
    Task RunScheduledTasksAsync();
}