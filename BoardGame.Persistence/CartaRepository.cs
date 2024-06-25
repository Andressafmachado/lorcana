using boardGame;
using BoardGame.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BoardGame.Persistence;

internal class CartaRepository : IRepository<Carta>
{
    
    private readonly ContextLorcana _context;
    
    public CartaRepository(ContextLorcana context)
    {
        _context = context;
    }
    
    public async Task<List<Carta>> GetAll()
    {
        return await _context.Cartas.ToListAsync();
    }

    public async Task<Carta> GetById(int id)
    {
        return await _context.Cartas.FindAsync(id) ?? throw new Exception("Carta não encontrada"); 
    }

    public async Task<Carta> Create(Carta carta)
    {
        await _context.Cartas.AddAsync(carta);
        await _context.SaveChangesAsync();
        return carta;
    }

    public async Task<Carta> Update(Carta carta)
    {
        var cartaEncontrada = await _context.Cartas.FindAsync(carta.CartaId);
        if (carta == null)
        {
            throw new Exception("Carta não encontrada");
        }

        cartaEncontrada = carta;
        await _context.SaveChangesAsync();
        return carta;
    }

    public async Task Delete(int id)
    {
        var carta = await _context.Cartas.FindAsync(id);
        if (carta == null)
        {
            throw new Exception("Carta não encontrada");
        }
        
        _context.Cartas.Remove(carta);
        await _context.SaveChangesAsync();
    }
}