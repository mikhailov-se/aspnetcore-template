using MediatR;

using Template.DomainServices.Books.Commands.RemoveBooks.Contracts;
using Template.ExternalServices.Books;

namespace Template.DomainServices.Books.Commands.RemoveBooks;

internal sealed class RemoveBookInternalHandler : IRequestHandler<RemoveBookCommandInternal, RemoveBookCommandInternalResponse>
{
    private readonly IBooksClient _booksClient;

    public RemoveBookInternalHandler(IBooksClient booksClient)
    {
        _booksClient = booksClient;
    }

    public async Task<RemoveBookCommandInternalResponse> Handle(RemoveBookCommandInternal request, CancellationToken cancellationToken)
    {
        await _booksClient.RemoveBook(request.BookId, cancellationToken);

        return new RemoveBookCommandInternalResponse(request.BookId);
    }
}