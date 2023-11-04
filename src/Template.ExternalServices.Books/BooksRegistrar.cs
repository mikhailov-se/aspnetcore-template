using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Template.ExternalServices.Books;

public sealed class BooksRegistrar
{
    public static void Configure(IConfiguration configuration, IServiceCollection services)
    {
        //register remote grpc client
        services.AddSingleton<IBooksClient, BooksClient>();
    }
}