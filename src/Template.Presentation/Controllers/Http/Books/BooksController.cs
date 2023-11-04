using MediatR;

using Microsoft.AspNetCore.Mvc;

using Template.Abstractions;
using Template.DomainServices.Books.Queries.GetBooks.Contracts;
using Template.Presentation.Converters;

namespace Template.Presentation.Controllers.Http.Books;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private readonly IMediator _mediator;

    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<GetBookQueryResponse> GetBook([FromQuery] GetBookQuery query, CancellationToken cancellationToken)
    {
        var internalQuery = new GetBookQueryInternal(query.BookId);

        GetBookQueryInternalResponse internalResponse = await _mediator.Send(internalQuery, cancellationToken);

        var response = new GetBookQueryResponse
        {
            Book = BookDtoConverter.ToDto(internalResponse.BookInternal)
        };

        return response;
    }
}