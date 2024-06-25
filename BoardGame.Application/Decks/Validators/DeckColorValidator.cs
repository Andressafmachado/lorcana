using boardGame;

namespace BoardGame.Application.Decks.Validators;

public class DeckColorValidator
{
    public bool ValidateColor(Deck deck)
    {
        var colors = deck.Cartas.Select(c => c.Cor).Distinct().ToList();
        return colors.Count <= 2;
    }
}