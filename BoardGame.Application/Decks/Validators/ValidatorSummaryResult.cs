namespace BoardGame.Application.Decks.Validators;

public class ValidatorSummaryResult
{
    public bool IsValid() => Errors.Where(c => c is not null).Count() == 0;
    public List<Error>? Errors { get; set; } = new List<Error>();
}