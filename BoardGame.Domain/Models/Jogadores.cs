﻿
namespace boardGame;

public class Jogador
{
    public string? Nome { get; set; }
    public int JogadorId { get; set; }
    public int DeckId { get; set; }
    public Deck? Deck { get; set; }

    public List<Carta>? CartasNaMão { get; set; }

    // Context context = new Context();

    public void ComprarCarta(int quantidade)
    {
        try
        {
            Random random = new Random();

            for (int i = 0; i < quantidade; i++)
            {

                if (Deck.Cartas.Count == 0)
                {
                    Console.WriteLine("O deck está vazio.");
                    return;
                }

                int index = random.Next(0, Deck.Cartas.Count);
                Carta cartaComprada = Deck.Cartas[index];
                CartasNaMão.Add(cartaComprada);
                Deck.Cartas.RemoveAt(index);

                Console.WriteLine($"O jogador {Nome} comprou a carta {cartaComprada.Nome}(id: {cartaComprada.CartaId}).");
                // context.SaveChanges();
                // var deck = context.Decks.Include(c => c.Cartas).FirstOrDefault(c => c.DeckId == DeckId );
            }

        }
        catch (System.Exception)
        {

            throw;
        }
    }

    public void ExecutarMulligan(List<Carta> cartas) {
        ComprarCarta(cartas.Count);
        DevolverAoDeck(cartas);
        //add shuffle
    }

    public void DevolverAoDeck(List<Carta> cartas) {
        Deck.Cartas.AddRange(cartas);
        CartasNaMão.RemoveRange(0, cartas.Count);
    }

    public void ExecutarAçõesDoTurno(bool turnoInitial = false)
    {
        Carta carta = new Personagem();
        List<Carta> cartas = new List<Carta>();


        ComprarCarta(1);

        BaixarCartaNaReservaDeTinta(carta); // nao pode ser a mesma carta para todos
        BaixarCartaNaTintaFresca(carta);
        MoverCartaParaCampoAtivo(carta);
        MoverCartaParaJornada(cartas);
        TaparEDestaparCarta(cartas);
    }

    public void BaixarCartaNaReservaDeTinta(Carta carta)
    {

    }

    public void BaixarCartaNaTintaFresca(Carta carta)
    {

    }

    public void MoverCartaParaCampoAtivo(Carta carta)
    {

    }

    public void MoverCartaParaJornada(List<Carta> cartas)
    {

    }

    public void TaparEDestaparCarta(List<Carta> cartas)
    {

    }

}
