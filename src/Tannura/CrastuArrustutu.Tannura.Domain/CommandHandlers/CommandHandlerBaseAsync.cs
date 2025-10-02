using Microsoft.Extensions.Logging;
using Muflone.Messages.Commands;
using Muflone.Persistence;

namespace CrastuArrustutu.Tannura.Domain.CommandHandlers;

public abstract class CommandHandlerBaseAsync<T>(IRepository repository, ILoggerFactory loggerFactory)
    : CommandHandlerAsync<T>(repository, loggerFactory)
    where T : class, ICommand
{
    public override async Task HandleAsync(T command, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            await ProcessCommandAsync(command, cancellationToken);
        }
        catch (Exception ex)
        {
            Logger.LogError(
                $"Error processing command: {command.GetType()} - Aggregate: {command.AggregateId} - CommandId : {command.MessageId} - Messagge: {ex.Message} - Stack Trace {ex.StackTrace}");
            throw;
        }
    }
    
    public abstract Task ProcessCommandAsync(T command, CancellationToken cancellationToken = default);
}