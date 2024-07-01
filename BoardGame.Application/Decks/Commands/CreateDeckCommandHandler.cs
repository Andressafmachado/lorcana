using boardGame;
using MediatR;

namespace BoardGame.Application.Decks.Commands;

internal sealed class CreateDeckCommandHandler : IRequestHandler<CreateDeckCommand>
{
    private readonly ICrudService<Deck> _crudService;
    
    public CreateDeckCommandHandler(ICrudService<Deck> crudService)
    {
        _crudService = crudService;
    }
    
    public async Task<Unit> Handle(CreateDeckCommand request, CancellationToken cancellationToken)
    {
        
        var deck = new Deck
        {
            Nome = request.Name,
            DeckId = request.DeckId
        };
        
        var crud =  await _crudService.Create(deck);
        if (crud is null)
        {
            return Unit.Value;
        }
       
        return Unit.Value;
    }
}