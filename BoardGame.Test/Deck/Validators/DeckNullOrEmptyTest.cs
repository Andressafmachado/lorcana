using BoardGame.Application.Decks.Validators;
using BoardGame.Test.Stub;

namespace BoardGame.Test.Deck.Validators;

public class DeckNullOrEmptyTest
{
    private DeckNullOrEmptyCardsValidator _sut;
    
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _sut = new DeckNullOrEmptyCardsValidator();

    }
    
    
    [Test]
    public void Validate_WhenDeckIsNull_ShouldReturnFalse()
    {
        // Arrange
        var deck = JogoStub.Deck();
        deck.Cartas = null;
        var expected = false;

        // Act
        var actual = _sut.Validate(deck);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}