using CreatorMauiApp.ViewModels;

namespace CreatorMauiApp.Views;

public partial class MetricsPage : ContentPage
{
    public MetricsPage(MetricsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
