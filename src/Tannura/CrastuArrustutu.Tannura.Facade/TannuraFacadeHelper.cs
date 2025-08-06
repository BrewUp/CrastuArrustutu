using Microsoft.Extensions.DependencyInjection;

namespace CrastuArrustutu.Tannura.Facade;

public static class TannuraFacadeHelper
{
    public static IServiceCollection AddTannuraFacade(this IServiceCollection services)
    {
        // Register any services related to the Carnizzaro facade here
        // Example: services.AddScoped<ICarnizzaroService, CarnizzaroService>();

        return services;
    }
}