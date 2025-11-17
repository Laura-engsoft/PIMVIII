using System.Collections.ObjectModel;
using System.Windows.Input;
using CreatorMauiApp.Models;

namespace CreatorMauiApp.ViewModels;

public class PlaylistsViewModel : BaseViewModel
{
    private string _newPlaylistName = string.Empty;
    private string _statusMessage = "Gerencie suas coleções de conteúdo.";

    public ObservableCollection<PlaylistItemModel> Playlists { get; } = new([
        new PlaylistItemModel { Name = "Lançamentos da Semana", ContentCount = 8, UpdatedAt = DateTime.Now.AddHours(-2) },
        new PlaylistItemModel { Name = "Favoritos da Comunidade", ContentCount = 15, UpdatedAt = DateTime.Now.AddDays(-1) },
        new PlaylistItemModel { Name = "Sessões Ao Vivo", ContentCount = 5, UpdatedAt = DateTime.Now.AddDays(-3) }
    ]);

    public string NewPlaylistName
    {
        get => _newPlaylistName;
        set => SetProperty(ref _newPlaylistName, value);
    }

    public string StatusMessage
    {
        get => _statusMessage;
        set => SetProperty(ref _statusMessage, value);
    }

    public ICommand CreatePlaylistCommand { get; }
    public ICommand EditPlaylistCommand { get; }
    public ICommand DeletePlaylistCommand { get; }

    public PlaylistsViewModel()
    {
        CreatePlaylistCommand = new Command(CreatePlaylist);
        EditPlaylistCommand = new Command<PlaylistItemModel>(EditPlaylist);
        DeletePlaylistCommand = new Command<PlaylistItemModel>(DeletePlaylist);
    }

    private void CreatePlaylist()
    {
        if (string.IsNullOrWhiteSpace(NewPlaylistName))
        {
            StatusMessage = "Defina um nome antes de criar uma playlist.";
            return;
        }

        var playlist = new PlaylistItemModel
        {
            Name = NewPlaylistName,
            ContentCount = Random.Shared.Next(1, 10),
            UpdatedAt = DateTime.Now
        };

        Playlists.Insert(0, playlist);
        StatusMessage = $"Playlist \"{playlist.Name}\" criada.";
        NewPlaylistName = string.Empty;
    }

    private void EditPlaylist(PlaylistItemModel? playlist)
    {
        if (playlist is null)
        {
            StatusMessage = "Selecione uma playlist para editar.";
            return;
        }

        playlist.UpdatedAt = DateTime.Now;
        playlist.ContentCount += 1;
        // Force refresh
        var index = Playlists.IndexOf(playlist);
        if (index >= 0)
        {
            Playlists.RemoveAt(index);
            Playlists.Insert(index, playlist);
        }

        StatusMessage = $"Playlist \"{playlist.Name}\" atualizada.";
    }

    private void DeletePlaylist(PlaylistItemModel? playlist)
    {
        if (playlist is null)
        {
            StatusMessage = "Selecione uma playlist para excluir.";
            return;
        }

        Playlists.Remove(playlist);
        StatusMessage = $"Playlist \"{playlist.Name}\" removida.";
    }
}
