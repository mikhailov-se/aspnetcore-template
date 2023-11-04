namespace Template.Domain.Exceptions;

public sealed class RemoveBookException : Exception
{
    public RemoveBookException(string? message) : base(message)
    {
    }
}