using boardGame;
using Microsoft.AspNetCore.Mvc;

namespace BoardGame.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EfeitoController : Controller
{
    // GET
    private readonly ICrud<Efeito> _crud;

    public EfeitoController(ICrud<Efeito> crud)
    {
        _crud = crud;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Efeito>>> ListEfeitos()
    {
        return await _crud.GetAll();
    }

    [HttpGet("{id}")]
        public async Task<ActionResult<Efeito>> GetEfeito(int id)
        {
            var efeito = await _crud.GetById(id);

            if (efeito == null)
            {
                return NotFound();
            }

            return efeito;
        }

    
        [HttpPost]
        public async Task<ActionResult<Efeito>> PostEfeito(Efeito efeito)
        {
            var efeitoCriado = await _crud.Create(efeito);

            return CreatedAtAction(nameof(GetEfeito), new { id = efeitoCriado.EfeitoId }, efeitoCriado);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEfeito(Efeito efeito)
        {
            
            await _crud.Update(efeito);

            return NoContent();
        }

    
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEfeito(int id)
        {
            await _crud.Delete(id);

            return NoContent();
        }
}