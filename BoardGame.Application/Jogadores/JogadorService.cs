using boardGame;
using BoardGame.Domain.Repositories;

namespace BoardGame.Application.Jogadores;

public class JogadorService : ICrudService<Jogador>
{
    
    private readonly IRepository<Jogador> _repository;

    public JogadorService(IRepository<Jogador> repository)
    {
        _repository = repository;
    }
    public async Task<List<Jogador>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task<Jogador> GetById(int id)
    {
        return await _repository.GetById(id);
    }

    public async Task<Jogador> Create(Jogador entity)
    {
        return await _repository.Create(entity);
    }

    public async Task<Jogador> Update(Jogador entity)
    {
       return await _repository.Update(entity);
    }

    public Task Delete(int id)
    {
        return _repository.Delete(id);
    }
}