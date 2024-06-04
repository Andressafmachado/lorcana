using System.Collections.Generic;

namespace boardGame;


public interface ICrud
{
    Task<List<Carta>> GetCartas();
    Task<Carta> GetCarta(int id);
    Task<Carta> PostCarta(Carta carta);
    Task PutCarta(Carta carta);
    Task DeleteCarta(int id);

} 