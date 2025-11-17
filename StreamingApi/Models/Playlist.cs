using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamingApi.Models;

public class Playlist
{
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string Nome { get; set; } = string.Empty;

    [ForeignKey(nameof(Usuario))]
    public int UsuarioId { get; set; }

    public Usuario? Usuario { get; set; }

    public ICollection<ItemPlaylist> Itens { get; set; } = new List<ItemPlaylist>();
}
