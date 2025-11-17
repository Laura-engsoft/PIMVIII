using CreatorMauiApp.ViewModels;

namespace CreatorMauiApp.Views;

public partial class PlaylistsPage : ContentPage
{
    public PlaylistsPage(PlaylistsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
