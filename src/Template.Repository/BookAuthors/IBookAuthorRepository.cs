using Template.Domain.BookAuthors;

namespace Template.Repository.BookAuthors;

public interface IBookAuthorRepository
{
    Task UpdateAuthor(BookAuthor bookAuthor, CancellationToken cancellationToken);
}