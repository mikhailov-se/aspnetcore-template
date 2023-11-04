namespace Template.ExternalServices.Books;

public interface IBooksClient
{
    Task<BookResponse> GetBook(long bookId, CancellationToken cancellationToken);
    Task RemoveBook(long bookId, CancellationToken cancellationToken);
}