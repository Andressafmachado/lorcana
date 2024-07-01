using BoardGame.Application.Decks.Validators;
using BoardGame.Test.Stub;

namespace BoardGame.Test.Deck.Validators;

public class DeckValidateTest
{
    private DeckMissingCardsValidator _sut;
    
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _sut = new DeckMissingCardsValidator();

    }
    
    
    [Test]
    public void Validate_WhenCardsInDeckIsNull_ShouldReturnFalse()
    {
        // Arrange
        var deck = JogoStub.Deck();
        deck.Cartas = null;
        var expected = "Deck is null or empty";

        // Act
        var actual = _sut.Validate(deck);

        // Assert
        Assert.AreEqual(expected, actual.Message);
    }

    // [Test]
    // public void Validate_WhenDeckIsValid_ShouldReturnTrue()
    // {
    //     // Arrange
    //     var deck = JogoStub.Deck(); 
    //     var expected = true;
    //
    //     // Act
    //     var actual = _sut.Validate(deck);
    //
    //     // Assert
    //     Assert.AreEqual(expected, actual);
    // }
    //
    // [Test]
    // public void Validate_WhenDeckHasLessThan60Cards_ShouldReturnFalse()
    // {
    //     // Arrange
    //     var deck = JogoStub.InvalidDeck(); 
    //     var expected = false;
    //
    //     // Act
    //     var actual = _sut.Validate(deck);
    //
    //     // Assert
    //     Assert.AreEqual(expected, actual);
    // }
}