namespace boardGame;

public class Deck
{
    [Key]
    public int? DeckId { get; set; }
    public string Nome { get; set; }
    public List<Carta>? Cartas { get; set; }

}
