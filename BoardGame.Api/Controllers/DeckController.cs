using boardGame;
using Microsoft.AspNetCore.Mvc;

namespace BoardGame.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DeckController : Controller
{
    // GET
    private readonly ICrud<Deck> _crud;

    public DeckController(ICrud<Deck> crud)
    {
        _crud = crud;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Deck>>> ListDecks()
    {
        return await _crud.GetAll();
    }
}