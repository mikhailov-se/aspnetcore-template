using Template.Domain.BookAuthors;

namespace Template.Infrastructure.Converters;

internal sealed class BookAuthorDbConverter
{
    public static BookAuthor ToDomain(BookAuthorDb bookAuthorDb)
    {
        return new BookAuthor();
    }

    public static BookAuthorDb FromDomain(BookAuthor status)
    {
        return new BookAuthorDb();
    }
}