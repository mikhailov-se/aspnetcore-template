using MediatR;

namespace Template.DomainServices.Books.Commands.RemoveBooks.Contracts;

public sealed record RemoveBookCommandInternal(long BookId) : IRequest<RemoveBookCommandInternalResponse>;