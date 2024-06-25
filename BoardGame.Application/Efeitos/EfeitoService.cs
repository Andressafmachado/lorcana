using boardGame;
using BoardGame.Domain.Repositories;

namespace BoardGame.Application.Efeitos;

public class EfeitoService : ICrudService<Efeito>
{
    
    private readonly IRepository<Efeito> _repository;

    public EfeitoService(IRepository<Efeito> repository)
    {
        _repository = repository;
    }
    public async Task<List<Efeito>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task<Efeito> GetById(int id)
    {
        return await _repository.GetById(id);
    }

    public async Task<Efeito> Create(Efeito entity)
    {
        return await _repository.Create(entity);
    }

    public async Task<Efeito> Update(Efeito efeito)
    {
       return await _repository.Update(efeito);
    }

    public Task Delete(int id)
    {
        return _repository.Delete(id);
    }
}