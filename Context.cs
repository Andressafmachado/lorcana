
using boardGame;
using Microsoft.EntityFrameworkCore;

namespace EFExemplo;


public class Context : DbContext
{
    public Context()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "exemplo.db");
    }
    public string DbPath { get; }
    public DbSet<Turno> Turnos { get; set; }
    public DbSet<Deck> Decks { get; set; }
    public DbSet<Efeito> Efeitos { get; set; }
    public DbSet<Carta> Cartas { get; set; }
    public DbSet<Jogador> Jogadores { get; set; }
    public DbSet<Jogo> Jogos { get; set; }





    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source=lorcana.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        // Unable to create a 'DbContext' of type ''. The exception 'Unable to determine the relationship represented by navigation 'Jogador.Jogos' of type 'Jogo'. Either manually configure the relationship, or ignore this property using the '[NotMapped]' attribute or by using 'EntityTypeBuilder.Ignore' in 'OnModelCreating'.' was thrown while attempting to create an instance. For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728

         modelBuilder.Entity<Jogador>()
        .HasOne(j => j.Jogos)
        .WithMany(j => j.Jogadores)
        .HasForeignKey(j => j.JogoId);
    }

}