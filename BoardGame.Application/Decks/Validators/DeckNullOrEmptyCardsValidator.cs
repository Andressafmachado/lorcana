using boardGame;

namespace BoardGame.Application.Decks.Validators;

public class DeckNullOrEmptyCardsValidator
{
    public bool Validate(Deck deck)
    {
        return deck.Cartas != null || deck.Cartas?.Count > 0;
    }
}