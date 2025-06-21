using athenas_archive.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Topico> Topicos { get; set; }
    public DbSet<Resposta> Respostas { get; set; }
    public DbSet<Curtida> Curtidas { get; set; }
    public DbSet<Notificacao> Notificacoes { get; set; }
    public DbSet<LogAcao> LogAcoes { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<TopicoTag> TopicoTags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // --- Usuario Configuration ---
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nome).IsRequired();
            entity.HasIndex(e => e.Email).IsUnique();
            entity.Property(e => e.SenhaHash).IsRequired();
            entity.Property(e => e.Ativo).HasDefaultValue(true);
            entity.Property(e => e.Banido).HasDefaultValue(false);

            entity.HasOne(e => e.Role)
                  .WithMany(r => r.Usuarios)
                  .HasForeignKey(e => e.RoleId);
        });

        // --- Resposta Configuration (for self-referencing relationship) ---
        modelBuilder.Entity<Resposta>(entity =>
        {
            entity.HasOne(e => e.RespostaPai)
                  .WithMany(e => e.RespostasFilhas)
                  .HasForeignKey(e => e.RespostaPaiId)
                  .OnDelete(DeleteBehavior.Restrict); // Avoid cascade delete issues
        });

        // --- TopicoTag Configuration (Many-to-Many Composite Key) ---
        modelBuilder.Entity<TopicoTag>(entity =>
        {
            entity.HasKey(tt => new { tt.TopicoId, tt.TagId }); // Composite Key

            entity.HasOne(tt => tt.Topico)
                  .WithMany(t => t.TopicoTags)
                  .HasForeignKey(tt => tt.TopicoId);

            entity.HasOne(tt => tt.Tag)
                  .WithMany(t => t.TopicoTags)
                  .HasForeignKey(tt => tt.TagId);
        });
    }
}