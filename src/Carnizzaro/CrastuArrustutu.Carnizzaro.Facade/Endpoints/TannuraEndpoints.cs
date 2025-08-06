using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace CrastuArrustutu.Carnizzaro.Facade.Endpoints;

public static class CarnizzaroEndpoints
{
    public static IEndpointRouteBuilder MapCarnizzaroEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("v1/carnizzaro")
            .WithTags("Carnizzaro");

        return endpoints;
    }
}
