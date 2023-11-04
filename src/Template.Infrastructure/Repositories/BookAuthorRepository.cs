using Template.Domain.BookAuthors;
using Template.Repository.BookAuthors;

namespace Template.Infrastructure.Repositories;

internal sealed class BookAuthorRepository : IBookAuthorRepository
{
    public Task UpdateAuthor(BookAuthor bookAuthor, CancellationToken cancellationToken)
    {
        //call ef, ado, etc...
        throw new NotImplementedException();
    }
}