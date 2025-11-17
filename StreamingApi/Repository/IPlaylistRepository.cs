using StreamingApi.Models;

namespace StreamingApi.Repository;

public interface IPlaylistRepository
{
    List<Playlist> GetAllPlaylists();
    Playlist? GetPlaylistByID(int id);
    void AddPlaylist(Playlist playlist);
    void UpdatePlaylist(Playlist playlist);
    void DeletePlaylist(int id);
}
