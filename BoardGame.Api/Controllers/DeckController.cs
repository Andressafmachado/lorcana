using boardGame;
using BoardGame.Application.Decks.Commands;
using BoardGame.Application.Decks.Validators;
using BoardGame.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BoardGame.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DeckController : Controller
{

    private ISender _sender;
    public DeckController(ISender sender)
    {
        _sender = sender;
    }
    
    
    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<Deck>>> ListDecks()
    // {
    //     return await _crudService.GetAll();
    // }
    //
    // [HttpGet("{id}")]
    //     public async Task<ActionResult<Deck>> GetDeck(int id)
    //     {
    //         var deck = await _crudService.GetById(id);
    //
    //         if (deck == null)
    //         {
    //             return NotFound();
    //         }
    //
    //         return deck;
    //     }

    
        [HttpPost]
        public async Task<ActionResult<Deck>> PostDeck(CreateDeckCommand deck)
        {
            await _sender.Send(deck);

            return Ok();
        }
        
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutDeck(Deck deck)
        // {
        //     
        //     await _crudService.Update(deck);
        //
        //     return NoContent();
        // }
        //
        //
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteDeck(int id)
        // {
        //     await _crudService.Delete(id);
        //
        //     return NoContent();
        // }
}