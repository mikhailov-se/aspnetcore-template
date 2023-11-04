using System.Runtime.CompilerServices;

using MediatR;

using Microsoft.AspNetCore.Server.Kestrel.Core;

using Template.DomainServices;
using Template.DomainServices.Books.Commands.RemoveBooks.Contracts;
using Template.DomainServices.Books.Queries.GetBooks.Contracts;
using Template.ExternalServices.Books;
using Template.Infrastructure;
using Template.Presentation.BackgroundServices;
using Template.Presentation.Behaviors;
using Template.Presentation.Configuration.Kafka;
using Template.Presentation.Controllers.Grpc.Books;
using Template.Presentation.Tracing;

[assembly: InternalsVisibleTo("Template.IntegrationTests")]

namespace Template.Presentation;

//todo metrics
//todo traces
public class Startup
{
    public IWebHostEnvironment WebHostEnvironment;

    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
    {
        WebHostEnvironment = webHostEnvironment;
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services
            .AddMediatR(configuration => { configuration.RegisterServicesFromAssemblyContaining<GetBookQueryInternal>(); })
            .AddMemoryCache()
            .AddGrpc(option => { option.EnableDetailedErrors = true; });

        services.Configure<KestrelServerOptions>(options => options.AllowSynchronousIO = true);

        services
            .AddSingleton<IPipelineBehavior<RemoveBookCommandInternal, RemoveBookCommandInternalResponse>,
                RemoveBookCommandBehavior>();

        BooksRegistrar.Configure(Configuration, services);

        KafkaRegistrar.Configure(services);
        InfrastructureRegistrar.Configure(Configuration, services);
        DomainServicesRegistrar.Configure(Configuration, services);
        TracingRegistrar.Configure(services);

        services.AddHostedService<BookAuthorCacheWarmerBackgroundService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(
            endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGrpcService<BooksController>();
            });
    }
}