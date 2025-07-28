//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Maui;
//using Microsoft.Maui.Hosting;
//using SocialMediaAutomation.Core.Interfaces;
//using SocialMediaAutomation.Core.Services;
//using SocialMediaAutomation.Infrastructure.LDPlayer;
//using SocialMediaAutomation.Infrastructure.ProxyVPN;
//using SocialMediaAutomation.Platforms.Facebook;
//using SocialMediaAutomation.Platforms.Instagram;
//using SocialMediaAutomation.Platforms.TikTok;
//using SocialMediaAutomation.Platforms.XTwitter;
//using SocialMediaAutomation.Platforms.YouTube;
//using System.Threading.Tasks;
//using UI.Pages;

//var builder = MauiApp.CreateBuilder();

//builder
//    .UseMauiApp<App>()
//    .ConfigureFonts(fonts =>
//    {
//        fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
//    });

//// Register core services
//builder.Services.AddSingleton<IAccountService, AccountManager>();
//builder.Services.AddSingleton<ILDPlayerController, LDPlayerController>();
//builder.Services.AddSingleton<IProxyService, ProxyService>();
//builder.Services.AddSingleton<ITaskScheduler, TaskSchedulerService>();
//builder.Services.AddSingleton<ILogService, LogService>();
//builder.Services.AddSingleton<IAiService, AiService>();
//builder.Services.AddSingleton<LiteDbContext>();

//// Register platform services
//builder.Services.AddSingleton<TikTokService>();
//builder.Services.AddSingleton<FacebookService>();
//builder.Services.AddSingleton<YouTubeService>();
//builder.Services.AddSingleton<InstagramService>();
//builder.Services.AddSingleton<TwitterService>();

//// Register IPlatformService to TikTok by default for demo; swap as needed or create a factory
//builder.Services.AddSingleton<IPlatformService>(sp => sp.GetRequiredService<TikTokService>());

//// Register HttpClient for AI Service
//builder.Services.AddHttpClient<IAiService, AiService>();

//var app = builder.Build();

//return app;