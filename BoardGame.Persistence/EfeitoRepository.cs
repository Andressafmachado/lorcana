using boardGame;
using BoardGame.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BoardGame.Persistence;

internal class EfeitoRepository : IRepository<Efeito>
{
    private readonly ContextLorcana _context;
    
    public EfeitoRepository(ContextLorcana context)
    {
        _context = context;
    }
    
    public async Task<List<Efeito>> GetAll()
    {
        return await _context.Efeitos.ToListAsync();
    }

    public async Task<Efeito> GetById(int id)
    {
        return await _context.Efeitos.FindAsync(id) ?? throw new Exception("Efeito não encontrado");
    }

    public async Task<Efeito> Create(Efeito efeito)
    {
        await _context.Efeitos.AddAsync(efeito);
        await _context.SaveChangesAsync();
        return efeito;
    }

    public async Task<Efeito> Update(Efeito efeito)
    {
        var efeitoEncontrado = _context.Efeitos.Find(efeito.EfeitoId) ?? throw new Exception("Efeito não encontrado"); 
        efeitoEncontrado = efeito;
        await _context.SaveChangesAsync();
        return efeito;
    }

    public async Task Delete(int id)
    {
        var efeito = _context.Efeitos.Find(id) ?? throw new Exception("Efeito não encontrado");
        _context.Efeitos.Remove(efeito);
        await _context.SaveChangesAsync();
    }
}