using boardGame;
using Microsoft.AspNetCore.Mvc;

namespace BoardGame.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartasController : ControllerBase
    {

        private readonly ICrudService<Carta> _crudService;

        public CartasController(ICrudService<Carta> crudService)
        {
            _crudService = crudService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carta>>> GetCartas()
        {
            return await _crudService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Carta>> GetCarta(int id)
        {
            var carta = await _crudService.GetById(id);

            if (carta == null)
            {
                return NotFound();
            }

            return carta;
        }

        [HttpPost]
        public async Task<ActionResult<Carta>> PostCarta(Carta carta)
        {
            var cartaCriada = await _crudService.Create(carta);

            return CreatedAtAction(nameof(GetCarta), new { id = cartaCriada.CartaId }, cartaCriada);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarta(Carta carta)
        {
            
            await _crudService.Update(carta);

            return NoContent();
        }

        // DELETE: api/Cartas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarta(int id)
        {
            await _crudService.Delete(id);

            return NoContent();
        }
    }
}
