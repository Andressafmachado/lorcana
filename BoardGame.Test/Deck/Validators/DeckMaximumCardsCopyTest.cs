using BoardGame.Application.Decks.Validators;
using BoardGame.Test.Stub;

namespace BoardGame.Test.Deck.Validators;

public class DeckMaximumCardsCopyTest
{

    private DeckMaximumCardsCopy _sut;
    
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _sut = new DeckMaximumCardsCopy();
    }
    
    
    [Test]
    public void ValidateMaximumCardsCopy_WhenDeckHasLessThanFourCopiesOfTheSameCard_ShouldReturnTrue()
    {
        // Arrange
        var deck = JogoStub.Deck();
        var expected = true;
        
        // Act
        var actual = _sut.ValidateMaximumCardsCopy(deck);
        
        // Assert
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void ValidateMaximumCardsCopy_WhenDeckHasMoreThanFourCopiesOfTheSameCard_ShouldReturnFalse()
    {
        // Arrange
        var deck = JogoStub.InvalidDeck();
        var expected = false;
        
        // Act
        var actual = _sut.ValidateMaximumCardsCopy(deck);
        
        // Assert
        Assert.AreEqual(expected, actual);
    }
}