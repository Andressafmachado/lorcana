using BoardGame.Application.Decks.Validators;
using BoardGame.Domain.Shared;

namespace boardGame;

public interface IValidate <T> where T : class
{
    public Error Validate(T entity);
}