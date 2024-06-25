using boardGame;
using BoardGame.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BoardGame.Persistence;

internal class JogadorRepository : IRepository<Jogador>
{
    private readonly ContextLorcana _context;
    
    public JogadorRepository(ContextLorcana context)
    {
        _context = context;
    }
    
    public async Task<List<Jogador>> GetAll()
    {
        return await _context.Jogadores.ToListAsync();
    }

    public async Task<Jogador> GetById(int id)
    {
        return await _context.Jogadores.FindAsync(id) ?? throw new Exception("Jogador não encontrado");
    }

    public async Task<Jogador> Create(Jogador jogador)
    {
        await _context.Jogadores.AddAsync(jogador);
        await _context.SaveChangesAsync();
        return jogador;
    }

    public async Task<Jogador> Update(Jogador jogador)
    {
        var jogadorEncontrado = _context.Jogadores.Find(jogador.JogadorId) ?? throw new Exception("Jogador não encontrado"); 
        jogadorEncontrado = jogador;
        await _context.SaveChangesAsync();
        return jogador;
    }

    public async Task Delete(int id)
    {
        var jogador = _context.Jogadores.Find(id) ?? throw new Exception("Jogador não encontrado");
        _context.Jogadores.Remove(jogador);
        await _context.SaveChangesAsync();
    }
}