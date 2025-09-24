using Microsoft.Extensions.DependencyInjection;

namespace CrastuArrustutu.Tannura.Domain;

public static class TannuraDomainHelper
{
    public static IServiceCollection AddTannuraDomain(this IServiceCollection services)
    {
        // Register any services related to the Tannura domain here
        return services;
    }
}