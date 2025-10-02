using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;

namespace CrastuArrustutu.Carnizzaro.ReadModel.EventHandlers;

public abstract class DomainEventHandlerBaseAsync<T>(ILoggerFactory loggerFactory)
    : DomainEventHandlerAsync<T>(loggerFactory)
    where T : class, IDomainEvent
{
    protected readonly ILogger Logger = loggerFactory.CreateLogger<T>();

    public override async Task HandleAsync(T @event, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        try
        {
            await ProcessEventAsync(@event, cancellationToken);
        }
        catch (Exception ex)
        {
            Logger.LogError(
                $"Error processing command: {@event.GetType()} - EventId : {@event.MessageId} - Messagge: {ex.Message} - Stack Trace {ex.StackTrace}");
            throw;
        }
    }
    
    public abstract Task ProcessEventAsync(T command, CancellationToken cancellationToken = default);
}
    