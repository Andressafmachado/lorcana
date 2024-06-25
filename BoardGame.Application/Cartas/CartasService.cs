using boardGame;
using BoardGame.Domain.Repositories;

namespace BoardGame.Application.Cartas;
public class CartasService : ICrudService<Carta>
{

    private readonly IRepository<Carta> _repository;

    public CartasService(IRepository<Carta> repository)
    {
        _repository = repository;
    }
    
    public async Task<List<Carta>> GetAll()
    {
        return await _repository.GetAll();
    }
    public async Task<Carta> GetById(int id)
    {
        return await _repository.GetById(id);
    }
    public async Task<Carta> Create(Carta carta)
    {
        return await _repository.Create(carta);
    }
    public async Task<Carta> Update(Carta carta)
    {
        return await _repository.Update(carta);
    }
    public Task Delete(int id)
    {
        return _repository.Delete(id);
    }
}