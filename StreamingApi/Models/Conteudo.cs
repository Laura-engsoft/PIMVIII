using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamingApi.Models;

public class Conteudo
{
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Titulo { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Tipo { get; set; } = string.Empty;

    [ForeignKey(nameof(Criador))]
    public int CriadorId { get; set; }

    public Criador? Criador { get; set; }

    public ICollection<ItemPlaylist> ItensPlaylist { get; set; } = new List<ItemPlaylist>();
}
