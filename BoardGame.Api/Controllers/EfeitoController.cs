using boardGame;
using Microsoft.AspNetCore.Mvc;

namespace BoardGame.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EfeitoController : Controller
{
    // GET
    private readonly ICrudService<Efeito> _crudService;

    public EfeitoController(ICrudService<Efeito> crudService)
    {
        _crudService = crudService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Efeito>>> ListEfeitos()
    {
        return await _crudService.GetAll();
    }

    [HttpGet("{id}")]
        public async Task<ActionResult<Efeito>> GetEfeito(int id)
        {
            var efeito = await _crudService.GetById(id);

            if (efeito == null)
            {
                return NotFound();
            }

            return efeito;
        }

    
        [HttpPost]
        public async Task<ActionResult<Efeito>> PostEfeito(Efeito efeito)
        {
            var efeitoCriado = await _crudService.Create(efeito);

            return CreatedAtAction(nameof(GetEfeito), new { id = efeitoCriado.EfeitoId }, efeitoCriado);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEfeito(Efeito efeito)
        {
            
            await _crudService.Update(efeito);

            return NoContent();
        }

    
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEfeito(int id)
        {
            await _crudService.Delete(id);

            return NoContent();
        }
}