using Microsoft.EntityFrameworkCore;
using StreamingApi.Data;
using StreamingApi.Models;

namespace StreamingApi.Repository;

public class PlaylistRepository : IPlaylistRepository
{
    private readonly AppDbContext _context;

    public PlaylistRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Playlist> GetAllPlaylists()
    {
        return _context.Playlists
            .Include(p => p.Usuario)
            .Include(p => p.Itens)
                .ThenInclude(i => i.Conteudo)
            .ToList();
    }

    public Playlist? GetPlaylistByID(int id)
    {
        return _context.Playlists
            .Include(p => p.Usuario)
            .Include(p => p.Itens)
                .ThenInclude(i => i.Conteudo)
            .FirstOrDefault(p => p.Id == id);
    }

    public void AddPlaylist(Playlist playlist)
    {
        _context.Playlists.Add(playlist);
        _context.SaveChanges();
    }

    public void UpdatePlaylist(Playlist playlist)
    {
        _context.Playlists.Update(playlist);
        _context.SaveChanges();
    }

    public void DeletePlaylist(int id)
    {
        var playlist = _context.Playlists.Find(id);
        if (playlist is null)
        {
            return;
        }

        _context.Playlists.Remove(playlist);
        _context.SaveChanges();
    }
}
