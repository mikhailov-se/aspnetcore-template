using Grpc.Core;

using MediatR;

using Template.Abstractions;
using Template.DomainServices.Books.Queries.GetBooks.Contracts;
using Template.Presentation.Converters;

namespace Template.Presentation.Controllers.Grpc.Books;

internal sealed class BooksController : BooksService.BooksServiceBase
{
    private readonly IMediator _mediator;

    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override async Task<GetBookQueryResponse> GetBook(GetBookQuery request, ServerCallContext context)
    {
        var internalQuery = new GetBookQueryInternal(request.BookId);

        GetBookQueryInternalResponse internalResponse = await _mediator.Send(internalQuery, context.CancellationToken);

        var response = new GetBookQueryResponse
        {
            Book = BookDtoConverter.ToDto(internalResponse.BookInternal)
        };

        return response;
    }
}