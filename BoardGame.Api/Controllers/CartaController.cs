using Microsoft.AspNetCore.Mvc;
using EFExemplo;
using Microsoft.EntityFrameworkCore;

namespace boardGame.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartasController : ControllerBase
    {
        private readonly Context _context;

        public CartasController(Context context)
        {
            _context = context;
        }

        // GET: api/Cartas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carta>>> GetCartas()
        {
            return await _context.Cartas.ToListAsync();
        }

        // GET: api/Cartas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carta>> GetCarta(int id)
        {
            var carta = await _context.Cartas.FindAsync(id);

            if (carta == null)
            {
                return NotFound();
            }

            return carta;
        }

        // POST: api/Cartas
        [HttpPost]
        public async Task<ActionResult<Carta>> PostCarta(Carta carta)
        {
            _context.Cartas.Add(carta);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCarta), new { id = carta.CartaId }, carta);
        }

        // PUT: api/Cartas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarta(int id, Carta carta)
        {
            if (id != carta.CartaId)
            {
                return BadRequest();
            }

            _context.Entry(carta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Cartas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarta(int id)
        {
            var carta = await _context.Cartas.FindAsync(id);
            if (carta == null)
            {
                return NotFound();
            }

            _context.Cartas.Remove(carta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CartaExists(int id)
        {
            return _context.Cartas.Any(e => e.CartaId == id);
        }
    }
}
