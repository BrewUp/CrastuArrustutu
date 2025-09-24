using Microsoft.Extensions.DependencyInjection;

namespace CrastuArrustutu.Carnizzaro.Domain;

public static class CarnizzaroDomainHelper
{
    public static IServiceCollection AddCarnizzaroDomain(this IServiceCollection services)
    {
        // Register domain services, repositories, etc.
        // Example:
        // services.AddScoped<IMyDomainService, MyDomainService>();

        return services;
    }
}