using Template.Abstractions;
using Template.DomainServices.Contracts.Book;

namespace Template.Presentation.Converters;

internal static class BookDtoConverter
{
    public static BookDto ToDto(BookInternal bookInternal)
    {
        return new BookDto();
    }
}