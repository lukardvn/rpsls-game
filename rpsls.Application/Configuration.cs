using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using rpsls.Application.Behaviors;

namespace rpsls.Application;

public static class Configuration
{
    public static void RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        
        // services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        //
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }
}