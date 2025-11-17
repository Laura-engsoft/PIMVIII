using CreatorMauiApp.ViewModels;
using CreatorMauiApp.Views;

namespace CreatorMauiApp;

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
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // ViewModels
        builder.Services.AddSingleton<DashboardViewModel>();
        builder.Services.AddTransient<UploadViewModel>();
        builder.Services.AddTransient<PlaylistsViewModel>();
        builder.Services.AddTransient<MetricsViewModel>();

        // Views
        builder.Services.AddSingleton<DashboardPage>();
        builder.Services.AddTransient<UploadPage>();
        builder.Services.AddTransient<PlaylistsPage>();
        builder.Services.AddTransient<MetricsPage>();

        return builder.Build();
    }
}
