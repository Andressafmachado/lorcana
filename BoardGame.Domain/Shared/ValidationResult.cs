namespace BoardGame.Domain.Shared;

public sealed class ValidationResult : Result, IValidationResult
{


    private ValidationResult(Error[] errors)
        : base(false, errors)
    { }

    public static ValidationResult WithErrors(Error[] errors) => new(errors);

}



