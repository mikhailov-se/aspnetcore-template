namespace Template.ExternalServices.Books;

internal sealed class BooksClient : IBooksClient
{
    public Task<BookResponse> GetBook(long bookId, CancellationToken cancellationToken)
    {
        //call remote api
        throw new NotImplementedException();
    }

    public Task RemoveBook(long bookId, CancellationToken cancellationToken)
    {
        //call remote api
        throw new NotImplementedException();
    }
}