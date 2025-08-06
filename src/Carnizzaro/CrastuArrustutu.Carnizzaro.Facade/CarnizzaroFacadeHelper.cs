using Microsoft.Extensions.DependencyInjection;

namespace CrastuArrustutu.Carnizzaro.Facade;

public static class CarnizzaroFacadeHelper
{
    public static IServiceCollection AddCarnizzaroFacade(this IServiceCollection services)
    {
        // Register any services related to the Carnizzaro facade here
        // Example: services.AddScoped<ICarnizzaroService, CarnizzaroService>();

        return services;
    }
}