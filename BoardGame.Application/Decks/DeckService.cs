using boardGame;
using BoardGame.Domain.Repositories;

namespace BoardGame.Application.Decks;

public class DeckService : ICrudService<Deck>
{
    
    private readonly IRepository<Deck> _repository;

    public DeckService(IRepository<Deck> repository)
    {
        _repository = repository;
    }
    public async Task<List<Deck>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task<Deck> GetById(int id)
    {
        return await _repository.GetById(id);
    }

    public async Task<Deck> Create(Deck entity)
    {
        return await _repository.Create(entity);
    }

    public async Task<Deck> Update(Deck entity)
    {
       return await _repository.Update(entity);
    }

    public Task Delete(int id)
    {
        return _repository.Delete(id);
    }
}