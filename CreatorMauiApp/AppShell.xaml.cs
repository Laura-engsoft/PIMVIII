using CreatorMauiApp.Views;

namespace CreatorMauiApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(UploadPage), typeof(UploadPage));
        Routing.RegisterRoute(nameof(PlaylistsPage), typeof(PlaylistsPage));
        Routing.RegisterRoute(nameof(MetricsPage), typeof(MetricsPage));
    }
}
