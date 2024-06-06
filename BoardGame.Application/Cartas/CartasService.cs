using boardGame;
using Microsoft.EntityFrameworkCore;

namespace BoardGame.Persistence.Cartas;
public class CartasService : ICrud
{

    private readonly ContextLorcana _context;

    public CartasService(ContextLorcana context)
    {
        _context = context;
    }



    public async Task<List<Carta>> GetCartas()
    {
        return await _context.Cartas.ToListAsync();
    }
    public async Task<Carta> GetCarta(int id)
    {
        var carta = await _context.Cartas.FindAsync(id);
        return carta ?? throw new Exception("Carta não encontrada");
    }
    public Task<Carta> PostCarta(Carta carta)
    {
        throw new NotImplementedException();
    }
    public Task PutCarta(Carta carta)
    {
        throw new NotImplementedException();
    }
    public Task DeleteCarta(int id)
    {
        throw new NotImplementedException();
    }

}