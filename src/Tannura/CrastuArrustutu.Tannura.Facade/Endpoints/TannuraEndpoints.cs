using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace CrastuArrustutu.Tannura.Facade.Endpoints;

public static class TannuraEndpoints
{
    public static IEndpointRouteBuilder MapTannuraEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("v1/tannura")
            .WithTags("Tannura");

        return endpoints;
    }
}
