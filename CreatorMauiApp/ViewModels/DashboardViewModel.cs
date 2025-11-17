using System.Windows.Input;

namespace CreatorMauiApp.ViewModels;

public class DashboardViewModel : BaseViewModel
{
    public ICommand NavigateToUploadCommand { get; }
    public ICommand NavigateToPlaylistsCommand { get; }
    public ICommand NavigateToMetricsCommand { get; }

    public DashboardViewModel()
    {
        NavigateToUploadCommand = new Command(async () => await NavigateAsync(nameof(Views.UploadPage)));
        NavigateToPlaylistsCommand = new Command(async () => await NavigateAsync(nameof(Views.PlaylistsPage)));
        NavigateToMetricsCommand = new Command(async () => await NavigateAsync(nameof(Views.MetricsPage)));
    }

    private static Task NavigateAsync(string route)
        => Shell.Current.GoToAsync(route);
}
