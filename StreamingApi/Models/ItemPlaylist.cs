using System.ComponentModel.DataAnnotations.Schema;

namespace StreamingApi.Models;

public class ItemPlaylist
{
    [ForeignKey(nameof(Playlist))]
    public int PlaylistId { get; set; }

    public Playlist? Playlist { get; set; }

    [ForeignKey(nameof(Conteudo))]
    public int ConteudoId { get; set; }

    public Conteudo? Conteudo { get; set; }
}
