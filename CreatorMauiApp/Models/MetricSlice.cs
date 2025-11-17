namespace CreatorMauiApp.Models;

public class MetricSlice
{
    public string Label { get; set; } = string.Empty;
    public int Value { get; set; }
    public string Color { get; set; } = "#FFFFFF";
    public double Percentage { get; set; }
    public double DisplayHeight => Math.Max(40, Value * 2);
}
