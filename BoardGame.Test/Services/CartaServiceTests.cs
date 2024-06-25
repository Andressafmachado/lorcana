using boardGame;
using BoardGame.Application.Cartas;
using BoardGame.Domain.Repositories;
using NSubstitute;

namespace BoardGame.Test.Services;

public class CartaServiceTests
{
    private CartasService _sut;
    private IRepository<Carta> _cartasRepository;
    
    [OneTimeSetUp]
    public void Init()
    {
        _cartasRepository = Substitute.For<IRepository<Carta>>();
        _sut = new CartasService(_cartasRepository);
    }
    
    /*
    
    */
    [Test]
    public async Task Create_CriarUmaCarta()
    {
        // Arrange
        var carta = new Carta();
        _cartasRepository.Create(Arg.Any<Carta>()).Returns(carta);
        
        // Act
        var result = await _sut.Create(carta);
        
        // Assert
        Assert.That(result, Is.EqualTo(carta));
    }
    
    [Test]
    public async Task Create_CriarUmaNovaCarta()
    {
        // Arrange
        var carta = new Carta();
        _cartasRepository.Create(Arg.Any<Carta>()).Returns(carta);
        
        // Act
        var result = await _sut.Create(carta);
        
        // Assert
        await _cartasRepository.Received().Create(Arg.Any<Carta>());
    }
}