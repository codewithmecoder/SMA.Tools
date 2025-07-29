using Microsoft.Extensions.Logging;
using SMA.Tools.Core.Interfaces;
using SMA.Tools.Core.Services;
using SMA.Tools.Infrastructure.LdPlayer;

namespace SMA.Tools;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif
        // Register core services
        builder.Services.AddSingleton<IAccountService, AccountManager>();
        builder.Services.AddSingleton<ILdPlayerController, LdPlayerController>();
        builder.Services.AddSingleton<IProxyService, ProxyService>();
        builder.Services.AddSingleton<ITaskScheduler, TaskSchedulerService>();
        builder.Services.AddSingleton<ILogService, LogService>();
        builder.Services.AddSingleton<IAiService, AiService>();
        builder.Services.AddSingleton<LiteDbContext>();

        // Register platform services
        builder.Services.AddSingleton<TikTokService>();
        builder.Services.AddSingleton<FacebookService>();
        builder.Services.AddSingleton<YouTubeService>();
        builder.Services.AddSingleton<InstagramService>();
        builder.Services.AddSingleton<TwitterService>();

        // Register IPlatformService to TikTok by default for demo; swap as needed or create a factory
        builder.Services.AddSingleton<IPlatformService>(sp => sp.GetRequiredService<TikTokService>());

        // Register HttpClient for AI Service
        builder.Services.AddHttpClient<IAiService, AiService>();

        return builder.Build();
    }
}