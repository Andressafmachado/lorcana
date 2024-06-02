
using boardGame;
using Microsoft.EntityFrameworkCore;


namespace EFExemplo;


public class Context : DbContext
{
    public Context() {}

    public Context(DbContextOptions<Context> options): base(options) {}

    public string DbPath { get; }
    public DbSet<Turno> Turnos { get; set; }
    public DbSet<Deck> Decks { get; set; }
    public DbSet<Efeito> Efeitos { get; set; }
    public DbSet<Carta> Cartas { get; set; }
    public DbSet<Jogador> Jogadores { get; set; }
    public DbSet<Jogo> Jogos { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=sundaydatabase;UserId=postgres;Password=postgres;Include Error Detail=true;");
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

         modelBuilder.Entity<Jogador>()
        .HasOne(j => j.Jogos)
        .WithMany(j => j.Jogadores)
        .HasForeignKey(j => j.JogoId);
    }

}