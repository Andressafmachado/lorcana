using boardGame;
using BoardGame.Application.Decks.Validators;
using Microsoft.AspNetCore.Mvc;

namespace BoardGame.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DeckController : Controller
{
    // GET
    private readonly ICrudService<Deck> _crudService;
    

    public DeckController(ICrudService<Deck> crudService)
    {
        _crudService = crudService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Deck>>> ListDecks()
    {
        return await _crudService.GetAll();
    }

    [HttpGet("{id}")]
        public async Task<ActionResult<Deck>> GetDeck(int id)
        {
            var deck = await _crudService.GetById(id);

            if (deck == null)
            {
                return NotFound();
            }

            return deck;
        }

    
        [HttpPost]
        public async Task<ActionResult<Deck>> PostDeck(Deck deck)
        {
            var deckCriado = await _crudService.Create(deck);

            return CreatedAtAction(nameof(GetDeck), new { id = deckCriado.DeckId }, deckCriado);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeck(Deck deck)
        {
            
            await _crudService.Update(deck);

            return NoContent();
        }

    
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeck(int id)
        {
            await _crudService.Delete(id);

            return NoContent();
        }
}