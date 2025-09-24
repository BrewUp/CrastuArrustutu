using CrastuArrustutu.Carnizzaro.Domain;
using CrastuArrustutu.Carnizzaro.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace CrastuArrustutu.Carnizzaro.Facade;

public static class CarnizzaroFacadeHelper
{
    public static IServiceCollection AddCarnizzaroFacade(this IServiceCollection services)
    {
        // Register any services related to the Carnizzaro facade here

        services.AddCarnizzaroDomain();
        services.AddCarnizzaroInfrastructure();

        return services;
    }
}