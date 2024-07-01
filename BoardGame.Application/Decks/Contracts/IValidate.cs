using BoardGame.Application.Decks.Validators;

namespace boardGame;

public interface IValidate <T> where T : class
{
    public Error Validate(T entity);
}