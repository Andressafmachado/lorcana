using boardGame;
using BoardGame.Application.Cartas;
using BoardGame.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BoardGame.Persistence;

public static class PersistenceCollectionExtension
{
    public static IServiceCollection AddPersistenceCollection(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ContextLorcana>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        
        services.AddTransient<IRepository<Carta>, CartaRepository>();
        services.AddTransient<IRepository<Deck>, DeckRepository>();
        services.AddTransient<IRepository<Efeito>, EfeitoRepository>();
        services.AddTransient<IRepository<Jogador>, JogadorRepository>();

        return services;
    }
}