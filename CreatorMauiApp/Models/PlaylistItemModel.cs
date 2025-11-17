namespace CreatorMauiApp.Models;

public class PlaylistItemModel
{
    public string Name { get; set; } = string.Empty;
    public int ContentCount { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
