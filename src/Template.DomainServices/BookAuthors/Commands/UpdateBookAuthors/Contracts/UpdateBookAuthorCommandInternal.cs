using MediatR;

using Template.Domain.BookAuthors;

namespace Template.DomainServices.BookAuthors.Commands.UpdateBookAuthors.Contracts;

public sealed record UpdateBookAuthorCommandInternal(BookAuthor BookAuthor) : IRequest<UpdateBookAuthorCommandInternalResponse>;