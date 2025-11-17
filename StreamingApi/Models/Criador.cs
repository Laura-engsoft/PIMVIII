using System.ComponentModel.DataAnnotations;

namespace StreamingApi.Models;

public class Criador
{
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string Nome { get; set; } = string.Empty;

    public ICollection<Conteudo> Conteudos { get; set; } = new List<Conteudo>();
}
