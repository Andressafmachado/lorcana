using boardGame;
using Microsoft.AspNetCore.Mvc;

namespace BoardGame.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartasController : ControllerBase
    {

        private readonly ICrud<Carta> _crud;

        public CartasController(ICrud<Carta> crud)
        {
            _crud = crud;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carta>>> GetCartas()
        {
            return await _crud.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Carta>> GetCarta(int id)
        {
            var carta = await _crud.GetById(id);

            if (carta == null)
            {
                return NotFound();
            }

            return carta;
        }

        [HttpPost]
        public async Task<ActionResult<Carta>> PostCarta(Carta carta)
        {
            var cartaCriada = await _crud.Create(carta);

            return CreatedAtAction(nameof(GetCarta), new { id = cartaCriada.CartaId }, cartaCriada);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarta(Carta carta)
        {
            
            await _crud.Update(carta);

            return NoContent();
        }

        // DELETE: api/Cartas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarta(int id)
        {
            await _crud.Delete(id);

            return NoContent();
        }
    }
}
