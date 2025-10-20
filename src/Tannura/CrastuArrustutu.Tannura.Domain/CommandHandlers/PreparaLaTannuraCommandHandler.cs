using CrastuArrustutu.Tannura.SharedKernel.CustomTypes;
using CrastuArrustutu.Tannura.SharedKernel.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;

namespace CrastuArrustutu.Tannura.Domain.CommandHandlers;

public sealed class PreparaLaTannuraCommandHandler(IRepository repository, ILoggerFactory loggerFactory) 
    : CommandHandlerBaseAsync<PreparaLaTannura>(repository, loggerFactory)
{
    public override async Task ProcessCommandAsync(PreparaLaTannura command, CancellationToken cancellationToken = default)
    {
        Entities.Tannura aggregate = Entities.Tannura.Create((TannuraId) command.AggregateId);
        await Repository.SaveAsync(aggregate, Guid.NewGuid(), cancellationToken);
    }
}