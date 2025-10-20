using Microsoft.Extensions.DependencyInjection;
using Muflone.Eventstore.gRPC;

namespace CrastuArrustutu.Infrastructure;

public static class InfrastructureHelper
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        EventStoreSettings eventStoreSettings)
    {
        services.AddMufloneEventStore(eventStoreSettings.ConnectionString);

        return services;
    }
}