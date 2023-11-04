using MediatR;

namespace Template.DomainServices.Books.Queries.GetBooks.Contracts;

public sealed record GetBookQueryInternal(long BookId) : IRequest<GetBookQueryInternalResponse>;