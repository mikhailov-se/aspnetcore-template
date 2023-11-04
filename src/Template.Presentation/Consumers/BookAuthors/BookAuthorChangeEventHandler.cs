using MediatR;

using Template.DomainServices.BookAuthors.Commands.UpdateBookAuthors.Contracts;
using Template.Presentation.Consumers.BookAuthors.Contracts;

namespace Template.Presentation.Consumers.BookAuthors;

internal sealed class BookAuthorChangeEventHandler : IKafkaMessageHandler<BookAuthorChangeEventDto>
{
    private readonly IMediator _mediator;

    public BookAuthorChangeEventHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Handle(ConsumeResult<BookAuthorChangeEventDto> result, CancellationToken cancellationToken)
    {
        var command = new UpdateBookAuthorCommandInternal(result.Message.Value);
        await _mediator.Send(command, cancellationToken);
    }
}