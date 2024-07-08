using boardGame;
using BoardGame.Application.Decks.Commands;
using BoardGame.Domain.Shared;
using FluentValidation;

namespace BoardGame.Application.Decks.Validators;

public class DeckAmountCardsValidator : AbstractValidator<CreateDeckCommand>
{
    public DeckAmountCardsValidator()
    {
        RuleFor(c => c.Description).NotNull()
            .WithMessage("description can not be null");
    }
}