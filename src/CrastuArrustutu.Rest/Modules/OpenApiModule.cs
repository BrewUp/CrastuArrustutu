using Microsoft.OpenApi;
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
        document.Servers = [new OpenApiServer { Url = "/" }];
        document.Info = new OpenApiInfo
        {
          Title = "CrastuArrustutu API",
          Version = "v1.0",
          Description = "CrastuArrustutu API for managing a Crastu dishes",
          Contact = new OpenApiContact
          {
            Name = "CrastuArrustutu"
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
      options.WithTitle("BrewUp API")
              .WithTheme(ScalarTheme.None);
    });

    return app;
  }
}