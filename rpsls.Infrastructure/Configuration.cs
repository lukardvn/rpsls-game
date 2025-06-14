using Microsoft.Extensions.DependencyInjection;
using rpsls.Application.Interfaces;
using rpsls.Infrastructure.Services;

namespace rpsls.Infrastructure;

public static class Configuration
{
    public static void RegisterInfrastructureServices(this IServiceCollection services)
    {
        services.AddHttpClient<IRandomNumberProvider, RandomNumberProvider>();
    }   
}