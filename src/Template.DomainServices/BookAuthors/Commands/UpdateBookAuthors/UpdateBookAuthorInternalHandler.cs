using MediatR;

using Template.DomainServices.BookAuthors.Commands.UpdateBookAuthors.Contracts;
using Template.Repository.BookAuthors;

namespace Template.DomainServices.BookAuthors.Commands.UpdateBookAuthors;

internal sealed class UpdateBookAuthorInternalHandler : IRequestHandler<UpdateBookAuthorCommandInternal, UpdateBookAuthorCommandInternalResponse>
{
    private readonly IBookAuthorRepository _bookAuthorRepository;

    public UpdateBookAuthorInternalHandler(IBookAuthorRepository bookAuthorRepository)
    {
        _bookAuthorRepository = bookAuthorRepository;
    }

    public async Task<UpdateBookAuthorCommandInternalResponse> Handle(UpdateBookAuthorCommandInternal request, CancellationToken cancellationToken)
    {
        await _bookAuthorRepository.UpdateAuthor(request.BookAuthor, cancellationToken);

        return new UpdateBookAuthorCommandInternalResponse();
    }
}