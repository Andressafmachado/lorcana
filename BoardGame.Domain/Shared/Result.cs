namespace BoardGame.Domain.Shared;

public class Result
{
    public bool Succeeded { get; }
    public Error[]? Errors { get; }
    
    protected internal Result(bool succeeded, Error[]? errors)
    {
        Succeeded = succeeded;
        Errors = errors;
    }
    
    public static Result Success()
    {
        return new Result(true, null);
    }
    
    public static Result Failure(Error[] error)
    {
        return new Result(false, error);
    }
    
    public bool IsFailure => !Succeeded;
    public bool IsSuccess => Succeeded;
}

public class Result<T> : Result
{
    public T Value { get; }
    
    protected internal Result(bool succeeded, T value, Error[]? error) : base(succeeded, error)
    {
        Value = value;
    }
    
    public static Result<T> Success(T value)
    {
        return new Result<T>(true, value, null);
    }
    
    public new static Result<T> Failure(Error[] error)
    {
        return new Result<T>(false, default!, error);
    }
}

