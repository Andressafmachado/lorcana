using Microsoft.AspNetCore.Mvc;
using EFExemplo;
using Microsoft.EntityFrameworkCore;

namespace boardGame.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeckController : ControllerBase
    {
        private readonly Context _context;

        public DeckController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deck>>> GetDecks()
        {
            return await _context.Decks.Include(c => c.Cartas).ToListAsync();
        }

    
        [HttpGet("{id}")]
        public async Task<ActionResult<Deck>> GetDeck(int id)
        {
            var deck = await _context.Decks.FindAsync(id);

            if (deck == null)
            {
                return NotFound();
            }

            return deck;
        }

        [HttpPost]
        public async Task<ActionResult<Deck>> PostDeck(Deck deck)
        {
            // add try catch bdupdateexception
            // add middleware 
            _context.Decks.Add(deck);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostDeck), new { id = deck.DeckId }, deck);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeck(int id, Deck deck)
        {
            if (id != deck.DeckId)
            {
                return BadRequest();
            }

            _context.Entry(deck).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeckExiste(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(deck);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeck(int id)
        {
            var deck = await _context.Decks.FindAsync(id);
            if (deck == null)
            {
                return NotFound();
            }

            _context.Decks.Remove(deck);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool DeckExiste(int id)
        {
            return _context.Decks.Any(e => e.DeckId == id);
        }
    }
}
