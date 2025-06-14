using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace rpsls.Application;

public static class Configuration
{
    public static void RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}