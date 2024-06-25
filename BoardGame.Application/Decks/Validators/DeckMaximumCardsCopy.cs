using boardGame;

namespace BoardGame.Application.Decks.Validators;

public class DeckMaximumCardsCopy
{
    public bool ValidateMaximumCardsCopy(Deck deck)
    {
        var groupedCards = deck.Cartas.GroupBy(c => c.Nome).ToList();
        var result = true;
        foreach (var group in groupedCards)
        {
            result = !(group.Count() > 4);
            break;
        }
        return result;
    }
}