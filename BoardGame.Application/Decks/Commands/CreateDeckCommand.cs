using MediatR;

namespace BoardGame.Application.Decks.Commands;

public sealed record CreateDeckCommand(string Name, int DeckId, string? Description) : IRequest
{
    
}


