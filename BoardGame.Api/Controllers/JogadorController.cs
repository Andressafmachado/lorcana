using boardGame;
using Microsoft.AspNetCore.Mvc;

namespace BoardGame.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JogadorController : Controller
{
    // GET
    private readonly ICrudService<Jogador> _crudService;

    public JogadorController(ICrudService<Jogador> crudService)
    {
        _crudService = crudService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Jogador>>> ListJogadores()
    {
        return await _crudService.GetAll();
    }

    [HttpGet("{id}")]
        public async Task<ActionResult<Jogador>> GetJogador(int id)
        {
            var jogador = await _crudService.GetById(id);

            if (jogador == null)
            {
                return NotFound();
            }

            return jogador;
        }

    
        [HttpPost]
        public async Task<ActionResult<Jogador>> PostJogador(Jogador jogador)
        {
            var jogadorCriado = await _crudService.Create(jogador);

            return CreatedAtAction(nameof(GetJogador), new { id = jogadorCriado.JogadorId }, jogadorCriado);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJogador(Jogador jogador)
        {
            
            await _crudService.Update(jogador);

            return NoContent();
        }

    
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJogador(int id)
        {
            await _crudService.Delete(id);

            return NoContent();
        }
}