using MediatR;

using Template.Presentation.Tracing.Behaviors;

namespace Template.Presentation.Tracing;

internal sealed class TracingRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(TracingPipelineBehavior<,>));
    }
}