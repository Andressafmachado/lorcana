using Microsoft.AspNetCore.Mvc;
using EFExemplo;
using Microsoft.EntityFrameworkCore;
using boardGame;



namespace boardGame.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartasController : ControllerBase
    {

        private readonly ICrud _crud;

        public CartasController(ICrud crud)
        {
            _crud = crud;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carta>>> GetCartas()
        {
            return await _crud.GetCartas();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Carta>> GetCarta(int id)
        {
            var carta = await _crud.GetCarta(id);

            if (carta == null)
            {
                return NotFound();
            }

            return carta;
        }

        [HttpPost]
        public async Task<ActionResult<Carta>> PostCarta(Carta carta)
        {
            var cartaCriada = await _crud.PostCarta(carta);

            return CreatedAtAction(nameof(GetCarta), new { id = cartaCriada.CartaId }, cartaCriada);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarta(Carta carta)
        {
            
            await _crud.PutCarta(carta);

            return NoContent();
        }

        // DELETE: api/Cartas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarta(int id)
        {
            await _crud.DeleteCarta(id);

            return NoContent();
        }
    }
}
