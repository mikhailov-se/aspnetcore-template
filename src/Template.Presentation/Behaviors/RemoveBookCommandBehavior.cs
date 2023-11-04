using MediatR;

using Polly;
using Polly.Retry;

using Template.Domain.Exceptions;
using Template.DomainServices.Books.Commands.RemoveBooks.Contracts;

namespace Template.Presentation.Behaviors;

internal sealed class RemoveBookCommandBehavior : IPipelineBehavior<RemoveBookCommandInternal, RemoveBookCommandInternalResponse>
{
    private readonly AsyncRetryPolicy _policy = Policy
        .Handle<RemoveBookException>()
        .WaitAndRetryAsync(retryCount: 40, _ => TimeSpan.FromMilliseconds(50));

    public Task<RemoveBookCommandInternalResponse> Handle(
        RemoveBookCommandInternal request,
        RequestHandlerDelegate<RemoveBookCommandInternalResponse> next,
        CancellationToken cancellationToken)
    {
        return _policy.ExecuteAsync(_ => next(), cancellationToken);
    }
}