namespace BoardGame.Domain.Shared;

public interface IValidationResult
{
    public static readonly Error[] ValidationError = [new Error("ValidationError","A Validation error ocurred.")];
    Error[] Errors { get; }
}