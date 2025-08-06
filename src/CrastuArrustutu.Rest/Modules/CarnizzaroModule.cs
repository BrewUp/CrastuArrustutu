using CrastuArrustutu.Carnizzaro.Facade.Endpoints;

namespace CrastuArrustutu.Rest.Modules;

public class CarnizzaroModule : IModule
{
    public bool IsEnabled => true;
    public int Order => 0;
    
    public IServiceCollection Register(WebApplicationBuilder builder)
    {
        
        return builder.Services;
    }

    public WebApplication Configure(WebApplication app)
    {
        app.MapCarnizzaroEndpoints();
        
        return app;
    }
}