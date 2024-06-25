
using boardGame;
using Microsoft.EntityFrameworkCore;


namespace BoardGame.Persistence;


internal class ContextLorcana : DbContext
{
    
    public ContextLorcana() {}

    public ContextLorcana(DbContextOptions<ContextLorcana> options): base(options) {}

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
}