using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;

namespace CrastuArrustutu.Rest.Modules;

public class OpenApiModule : IModule
{
    public bool IsEnabled => true;
    public int Order => 0;

    public IServiceCollection Register(WebApplicationBuilder builder)
    {
        builder.Services.AddOpenApi(options =>
        {
            options.AddDocumentTransformer((document, _, _) =>
            {
                document.Servers = [new OpenApiServer {Url = "/"}];
                document.Info = new OpenApiInfo
                {
                    Title = "CastruArrututu API",
                    Version = "v1.0",
                    Description = "CastruArrututu API",
                    Contact = new OpenApiContact
                    {
                        Name = "CastruArrututu"
                    }
                };

                return Task.CompletedTask;
            });
        });

        return builder.Services;
    }

    public WebApplication Configure(WebApplication app)
    {
        app.MapOpenApi();
        app.MapScalarApiReference(options =>
        {
            options.WithTitle("CastruArrututu API")
                .WithTheme(ScalarTheme.None);
        });

        return app;
    }
}