using CrastuArrustutu.Infrastructure;

namespace CrastuArrustutu.Rest.Modules;

public class InfrastructureModule : IModule
{
    public bool IsEnabled => true;
    public int Order => 0;
    
    public IServiceCollection Register(WebApplicationBuilder builder)
    {
        builder.Services.AddInfrastructure(builder.Configuration.GetSection("CrastuArrustutu:EventStore")
            .Get<EventStoreSettings>()!);
        
        builder.Services.AddAntiforgery(options =>
        {
            // Set Cookie properties using CookieBuilder properties†.
            options.HeaderName = "X-CSRF-TOKEN";
            options.SuppressXFrameOptionsHeader = false;
        });
        
        return builder.Services;
    }

    public WebApplication Configure(WebApplication app)
    {
        app.UseAntiforgery();
        app.UseRequestLocalization();
        
        return app;
    }
}