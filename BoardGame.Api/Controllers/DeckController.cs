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
    private readonly DeckColorValidator _deckColorValidator;
    private readonly DeckMaximumCardsCopy _deckMaximumCardsCopy;
    private readonly DeckMinimumCardsAmountValidator _deckMinimumCardsAmountValidator;
    private readonly DeckNullOrEmptyCardsValidator _deckNullOrEmptyCardsValidator;

    public DeckController(ICrudService<Deck> crudService)
    {
        _crudService = crudService;
        _deckColorValidator = new DeckColorValidator();
        _deckMaximumCardsCopy = new DeckMaximumCardsCopy();
        _deckMinimumCardsAmountValidator = new DeckMinimumCardsAmountValidator();
        _deckNullOrEmptyCardsValidator = new DeckNullOrEmptyCardsValidator();
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
            if(_deckNullOrEmptyCardsValidator.Validate(deck) == false)
            {
                return BadRequest("Deck não pode ser vazio");
            }
            
            if(_deckColorValidator.ValidateColor(deck) == false)
            {
                return BadRequest("Deck não pode ter mais de 2 cores");
            }
            
            if(_deckMinimumCardsAmountValidator.ValidateMinimumCardsAmount(deck) == false)
            {
                return BadRequest("Deck não pode ter menos de 60 cartas");
            }
            
            if(_deckMaximumCardsCopy.ValidateMaximumCardsCopy(deck) == false)
            {
                return BadRequest("Deck não pode ter mais de 4 cópias da mesma carta");
            }
            
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