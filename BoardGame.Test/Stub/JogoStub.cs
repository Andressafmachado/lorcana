using boardGame;

namespace BoardGame.Test.Stub;

internal static class JogoStub
{
    internal static Deck Deck()
    {
        return new Deck()
        {
            DeckId = 1,
            Nome = "Frozen",
            Cartas = new List<Carta>()
            {
                new Carta(),
                new Carta(),
                new Carta(),
                new Carta(),
                new Carta(),
                new Carta(),
                new Carta(),
                new Carta(),
            }
        };
    }
}