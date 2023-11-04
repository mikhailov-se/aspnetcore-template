using Template.Domain.Books;
using Template.DomainServices.Contracts.Book;

namespace Template.DomainServices.Converters;

internal static class BookInternalConverter
{
    public static BookInternal FromDomain(Book book)
    {
        return new BookInternal();
    }
}