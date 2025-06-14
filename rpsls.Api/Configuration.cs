namespace rpsls.Api;

public static class Configuration
{
    public static void RegisterApiServices(this IServiceCollection services)
    {
        services.AddOpenApi();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}