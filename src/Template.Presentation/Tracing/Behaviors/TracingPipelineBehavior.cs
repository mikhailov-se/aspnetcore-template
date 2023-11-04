using MediatR;

namespace Template.Presentation.Tracing.Behaviors;

public sealed class TracingPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    // private readonly Tracer _tracer;

    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();

        // using (_tracer.BuildSpan(typeof(TRequest).Name).StartActive())
        // {
        //     return await next();
        // }
    }
}