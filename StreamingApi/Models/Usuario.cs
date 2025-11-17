using System.ComponentModel.DataAnnotations;

namespace StreamingApi.Models;

public class Usuario
{
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    public ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
}
