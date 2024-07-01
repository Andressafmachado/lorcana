// using boardGame;
// using BoardGame.Domain.Shared;
//
// namespace BoardGame.Application.Decks.Validators;
//
// public class DeckMissingCardsValidator : IValidate<Deck>
// {
//     public Error Validate(Deck deck)
//     {
//         Error error = null;
//         
//         
//         if(string.IsNullOrEmpty(deck?.Cartas?.ToString()))
//         {
//             error = new Error();
//             error.Message = "Deck is null or empty";
//             return error;
//         }
//             
//         // if(deck.Cartas?.Select(carta => carta.Cor).Distinct().Count() > 2)
//         // {
//         //     result.Errors.Add("Deck has more than 2 colors");
//         // }
//         //     
//         // if(deck.Cartas?.Count < 60)
//         // {
//         //     result.Errors.Add("Deck has less than 60 cards");
//         // }
//         //     
//         // if(deck.Cartas?.GroupBy(carta => carta.Nome).Any(carta => carta.Count() > 4) ?? false)
//         // {
//         //     result.Errors.Add("Deck has more than 4 cards with the same name");
//         // }
//
//         return error;
//     }
// }