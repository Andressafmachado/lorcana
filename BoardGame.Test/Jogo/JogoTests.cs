using boardGame;
using BoardGame.Test.Stub;

namespace BoardGame.Test;

public class JogoTests
{
    /*
    Apos o inicio do jogo, um jogador deve ter 7 cartas na mao
    */
    [Test]
    public void SetUp_DeveRetornar7CartasNaMao()
    {
        // Arrange
        var jogo = new Jogo();
        jogo.Jogadores = [];
        var jogador = new Jogador();
        jogador.CartasNaMão = [];
        
        jogador.Deck = JogoStub.Deck();
        
        // Act
        jogo.SetUp([jogador]);
        // Assert
        Assert.AreEqual(7, jogador.CartasNaMão.Count);
    }
    
    /*
    Apos o inicio do jogo, cada jogador deve ter 7 cartas na mao
    */
    [Test]
    public void SetUp_DeveRetornar7CartasNaMaoCadaJogador()
    {
        // Arrange
        var jogo = new Jogo();
        jogo.Jogadores = [];
        var jogador1 = new Jogador();
        jogador1.CartasNaMão = [];
        jogador1.Deck = JogoStub.Deck();
        
        var jogador2 = new Jogador();
        jogador2.CartasNaMão = [];
        jogador2.Deck = JogoStub.Deck();
        
        // Act
        jogo.SetUp([jogador1, jogador2]);
        
        // Assert
        Assert.That(jogador1.CartasNaMão.Count, Is.EqualTo(7));
        Assert.That(jogador2.CartasNaMão.Count, Is.EqualTo(7));
    }
    
    [OneTimeSetUp]
    public void Init()
    {
        Console.WriteLine("teste iniciado");
    }

    [SetUp]
    public void TestInit()
    {
       Console.WriteLine("teste rodando"); 
    }
}