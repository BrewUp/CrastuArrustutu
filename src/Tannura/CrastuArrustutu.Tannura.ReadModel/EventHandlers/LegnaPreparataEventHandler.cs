using CrastuArrustutu.Tannura.SharedKernel.Messages.Events;
using Microsoft.Extensions.Logging;

namespace CrastuArrustutu.Tannura.ReadModel.EventHandlers;

public sealed class LegnaPreparataEventHandler(ILoggerFactory loggerFactory) 
    : DomainEventHandlerBaseAsync<LegnaPreparata>(loggerFactory)
{
    public override Task ProcessEventAsync(LegnaPreparata command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}