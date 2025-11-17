using System.Collections.ObjectModel;
using CreatorMauiApp.Models;

namespace CreatorMauiApp.ViewModels;

public class MetricsViewModel : BaseViewModel
{
    private int _totalViews;
    private int _totalLikes;
    private int _totalUploads;

    public ObservableCollection<MetricSlice> ChartData { get; } = new();

    public int TotalViews
    {
        get => _totalViews;
        set => SetProperty(ref _totalViews, value);
    }

    public int TotalLikes
    {
        get => _totalLikes;
        set => SetProperty(ref _totalLikes, value);
    }

    public int TotalUploads
    {
        get => _totalUploads;
        set => SetProperty(ref _totalUploads, value);
    }

    public MetricsViewModel()
    {
        TotalViews = 128_450;
        TotalLikes = 42_210;
        TotalUploads = 86;

        LoadChart();
    }

    private void LoadChart()
    {
        ChartData.Clear();
        var slices = new[]
        {
            new MetricSlice { Label = "Orgânico", Value = 55, Color = "#7C3AED" },
            new MetricSlice { Label = "Campanhas", Value = 25, Color = "#06B6D4" },
            new MetricSlice { Label = "Colabs", Value = 20, Color = "#F97316" }
        };

        var total = slices.Sum(s => s.Value);
        foreach (var slice in slices)
        {
            slice.Percentage = Math.Round(slice.Value / (double)total, 2);
            ChartData.Add(slice);
        }
    }
}
