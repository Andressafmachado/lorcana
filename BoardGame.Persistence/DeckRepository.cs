using boardGame;
using BoardGame.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BoardGame.Persistence;

internal class DeckRepository : IRepository<Deck>
{
    private readonly ContextLorcana _context;
    
    public DeckRepository(ContextLorcana context)
    {
        _context = context;
    }
    
    public async Task<List<Deck>> GetAll()
    {
        return await _context.Decks.ToListAsync();
    }

    public async Task<Deck> GetById(int id)
    {
        return await _context.Decks.FindAsync(id) ?? throw new Exception("Deck não encontrado");
    }

    public async Task<Deck> Create(Deck deck)
    {
        await _context.Decks.AddAsync(deck);
        await _context.SaveChangesAsync();
        return deck;
    }

    public async Task<Deck> Update(Deck deck)
    {
        var deckEncontrado = _context.Decks.Find(deck.DeckId) ?? throw new Exception("Deck não encontrado"); 
        deckEncontrado = deck;
        await _context.SaveChangesAsync();
        return deck;
    }

    public async Task Delete(int id)
    {
        var deck = _context.Decks.Find(id) ?? throw new Exception("Deck não encontrado");
        _context.Decks.Remove(deck);
        await _context.SaveChangesAsync();
    }
}