namespace boardGame;

public class Carta

{
    public int CartaId { get; set; }
    public int Custo { get; set; }
    public TipoDaCarta Tipo { get; set; }
    public RaridadeDaCarta Raridade { get; set; }
    public string? Nome { get; set; }
    public CoresDaTinta Cor { get; set; }
    public string? Descrição { get; set; }
    public int? EfeitoId { get; set; }
    public Efeito? Efeito { get; set; }
    public int? DeckId { get; set; }
    public Deck? Deck { get; set; }
    public int Número { get; set; }
    public bool PodeVirarTinta { get; set; }
    
}

public class Personagem : Carta
{
    public string? NomeGlimmer { get; set; }
    public string? Classificação { get; set; }

    public int PoderDeAtaque { get; set; }
    public int ForçaDeVontade { get; set; }
    public int Lore { get; set; }
    
}

public class Item : Carta {

}

public class Canção : Carta {

}

public class Localização : Carta {

}

public class Ação : Carta {

}