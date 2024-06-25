using boardGame;

namespace BoardGame.Application.Decks.Validators;

public class DeckMinimumCardsAmountValidator
{
    public bool ValidateMinimumCardsAmount(Deck deck)
    {
        return deck.Cartas.Count <= 60;
    }
}