namespace RickAndMortyBLL.Exceptions;

public class RickAndMortyException : Exception
{
    public RickAndMortyException()
    {
    }

    public RickAndMortyException(string message)
        : base(message)
    {
    }

    public RickAndMortyException(string message, Exception inner)
        : base(message, inner)
    {
    }
}