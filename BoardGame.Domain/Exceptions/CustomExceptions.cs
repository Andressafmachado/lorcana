using System;

public class JogoException : Exception
{
    public JogoException() { }

    public JogoException(string message)
        : base(message) { }

    public JogoException(string message, Exception inner)
        : base(message, inner) { }
}
