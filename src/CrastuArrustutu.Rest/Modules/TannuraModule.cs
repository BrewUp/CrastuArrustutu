using CrastuArrustutu.Tannura.Facade;
using CrastuArrustutu.Tannura.Facade.Endpoints;

namespace CrastuArrustutu.Rest.Modules;

public class TannuraModule : IModule
{
    public bool IsEnabled => true;
    public int Order => 0;
    
    public IServiceCollection Register(WebApplicationBuilder builder)
    {
        builder.Services.AddTannuraFacade();
        
        return builder.Services;
    }

    public WebApplication Configure(WebApplication app)
    {
        app.MapTannuraEndpoints();

        return app;
    }
}