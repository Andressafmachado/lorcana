using boardGame;
using BoardGame.Application.Decks.Validators;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;


namespace Infrastructure.Middleware
{
    public class DeckValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly List<IValidate<Deck>> _deckValidators;

        public DeckValidationMiddleware(RequestDelegate next, List<IValidate<Deck>> deckValidators)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _deckValidators = deckValidators ?? throw new ArgumentNullException(nameof(deckValidators));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Read the request body as a string
            string bodyText;
            using (var memoryStream = new MemoryStream())
            {
                await context.Request.Body.CopyToAsync(memoryStream);
                bodyText = Encoding.UTF8.GetString(memoryStream.ToArray());
                
            }

            // Deserialize the body text to a Deck object
            var deck = JsonConvert.DeserializeObject<Deck>(bodyText);

            // Validate the deck
            var validateResult = new ValidatorSummaryResult();
            validateResult.Errors.AddRange(_deckValidators.Select(v => v.Validate(deck)));

            if (!validateResult.IsValid())
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "text/plain";
                var errors = string.Join("\n", validateResult.Errors
                    .Where(c => !string.IsNullOrEmpty(c.Message))
                    .Select(e => e.Message).ToList());

                await context.Response.WriteAsync(errors);
                return;
            }

            // Call the next middleware in the pipeline
            await _next(context);
        }
    }
}
