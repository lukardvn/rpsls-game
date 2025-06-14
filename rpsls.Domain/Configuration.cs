using rpsls.Domain.Interfaces;
using rpsls.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace rpsls.Domain;

public static class Configuration
{
    public static void RegisterDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IGameService, GameService>();
    }   
}