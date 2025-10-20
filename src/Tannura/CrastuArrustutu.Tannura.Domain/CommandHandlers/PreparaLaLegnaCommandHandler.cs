using CrastuArrustutu.Tannura.SharedKernel.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;

namespace CrastuArrustutu.Tannura.Domain.CommandHandlers;

public class PreparaLaLegnaCommandHandler(IRepository repository, ILoggerFactory loggerFactory)
    : CommandHandlerBaseAsync<PreparaLaLegna>(repository, loggerFactory)
{
    public override Task ProcessCommandAsync(PreparaLaLegna command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}