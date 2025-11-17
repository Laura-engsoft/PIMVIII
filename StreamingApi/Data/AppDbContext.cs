using Microsoft.EntityFrameworkCore;
using StreamingApi.Models;

namespace StreamingApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Criador> Criadores => Set<Criador>();
    public DbSet<Conteudo> Conteudos => Set<Conteudo>();
    public DbSet<Playlist> Playlists => Set<Playlist>();
    public DbSet<ItemPlaylist> ItensPlaylist => Set<ItemPlaylist>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Playlists)
            .WithOne(p => p.Usuario!)
            .HasForeignKey(p => p.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Criador>()
            .HasMany(c => c.Conteudos)
            .WithOne(conteudo => conteudo.Criador!)
            .HasForeignKey(conteudo => conteudo.CriadorId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Playlist>()
            .HasMany(p => p.Itens)
            .WithOne(i => i.Playlist!)
            .HasForeignKey(i => i.PlaylistId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Conteudo>()
            .HasMany(c => c.ItensPlaylist)
            .WithOne(i => i.Conteudo!)
            .HasForeignKey(i => i.ConteudoId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ItemPlaylist>()
            .HasKey(i => new { i.PlaylistId, i.ConteudoId });
    }
}
