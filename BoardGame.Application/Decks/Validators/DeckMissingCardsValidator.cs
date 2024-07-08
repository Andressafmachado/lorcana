using boardGame;
using BoardGame.Domain.Shared;
using FluentValidation;

namespace BoardGame.Application.Decks.Validators;

public class DeckMissingCardsValidator : AbstractValidator<Deck>
{
    public DeckMissingCardsValidator()
    {
        RuleFor(c => c.Cartas).NotNull()
            .WithMessage("Cards are required to create a deck");
    }
}