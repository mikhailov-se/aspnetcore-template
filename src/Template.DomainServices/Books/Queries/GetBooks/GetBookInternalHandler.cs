using MediatR;

using Microsoft.Extensions.Options;

using Template.DomainServices.Books.Queries.GetBooks.Contracts;
using Template.DomainServices.Converters;
using Template.ExternalServices.Books;
using Template.ExternalServices.Options;

namespace Template.DomainServices.Books.Queries.GetBooks;

internal sealed class GetBookInternalHandler : IRequestHandler<GetBookQueryInternal, GetBookQueryInternalResponse>
{
    private readonly IBooksClient _booksClient;
    private readonly IOptionsMonitor<BookClientOptions> _optionsMonitor;

    private int QueryTimeoutInSeconds => _optionsMonitor.CurrentValue.QueryTimeoutInSeconds;

    public GetBookInternalHandler(IBooksClient booksClient, IOptionsMonitor<BookClientOptions> optionsMonitor)
    {
        _booksClient = booksClient;
        _optionsMonitor = optionsMonitor;
    }

    public async Task<GetBookQueryInternalResponse> Handle(GetBookQueryInternal request, CancellationToken cancellationToken)
    {
        using CancellationTokenSource linkedCts = SetCancellation(cancellationToken);

        BookResponse response = await _booksClient.GetBook(request.BookId, linkedCts.Token);

        return new GetBookQueryInternalResponse(BookInternalConverter.FromDomain(response.Book));
    }

    private CancellationTokenSource SetCancellation(CancellationToken cancellationToken)
    {
        var commandTimeoutCts = new CancellationTokenSource(QueryTimeoutInSeconds);

        var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(commandTimeoutCts.Token, cancellationToken);

        return linkedCts;
    }
}