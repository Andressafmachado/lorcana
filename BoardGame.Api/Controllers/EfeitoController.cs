using boardGame;
using Microsoft.AspNetCore.Mvc;

namespace BoardGame.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DeckController : Controller
{
    // GET
    private readonly ICrud<Deck> _crud;

    public DeckController(ICrud<Deck> crud)
    {
        _crud = crud;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Deck>>> ListDecks()
    {
        return await _crud.GetAll();
    }

    [HttpGet("{id}")]
        public async Task<ActionResult<Deck>> GetDeck(int id)
        {
            var deck = await _crud.GetById(id);

            if (deck == null)
            {
                return NotFound();
            }

            return deck;
        }

    
        [HttpPost]
        public async Task<ActionResult<Deck>> PostDeck(Deck deck)
        {
            var deckCriado = await _crud.Create(deck);

            return CreatedAtAction(nameof(GetDeck), new { id = deckCriado.DeckId }, deckCriado);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeck(Deck deck)
        {
            
            await _crud.Update(deck);

            return NoContent();
        }

    
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeck(int id)
        {
            await _crud.Delete(id);

            return NoContent();
        }
}