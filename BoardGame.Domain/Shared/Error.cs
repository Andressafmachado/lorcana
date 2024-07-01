namespace BoardGame.Domain.Shared;

public class Error : IEquatable<Error>
{
    public string? Message { get; }
    public string Code { get; }

    public static readonly Error None = new Error(string.Empty, string.Empty);
    
    
    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }
    
    // override ToString() to return the message
    public static implicit operator string(Error error) => error.Message ?? string.Empty;

    public virtual bool Equals(Error? other)
    {
        if (other is null)
        {
            return false;
        }
        
        return Code == other.Code && Message == other.Message;
    }

    public override bool Equals(object? obj)
    {
        // se obj for error, sera asigned a error, e chama a funcao Equals com error pra executar linha 27
        return obj is Error error && Equals(error);
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(Message, Code);
    }

    public override string ToString()
    {
        return Code;
    }
}