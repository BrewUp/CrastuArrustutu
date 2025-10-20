using CrastuArrustutu.Tannura.Domain.CommandHandlers;
using CrastuArrustutu.Tannura.SharedKernel.CustomTypes;
using CrastuArrustutu.Tannura.SharedKernel.Messages.Commands;
using CrastuArrustutu.Tannura.SharedKernel.Messages.Events;
using Microsoft.Extensions.Logging.Abstractions;
using Muflone.Messages.Commands;
using Muflone.Messages.Events;
using Muflone.SpecificationTests;

namespace CrastuArrustutu.Tannura.Tests.Entities;

public sealed class PreparaLaTannuraSuccessfully : CommandSpecification<PreparaLaTannura>
{
    private readonly TannuraId _tannuraId = new TannuraId(Guid.NewGuid().ToString());
    
    protected override IEnumerable<DomainEvent> Given()
    {
        yield break;
    }

    protected override PreparaLaTannura When() => new PreparaLaTannura(_tannuraId);

    protected override ICommandHandlerAsync<PreparaLaTannura> OnHandler()
    {
        return new PreparaLaTannuraCommandHandler(Repository, new NullLoggerFactory());
    }

    protected override IEnumerable<DomainEvent> Expect()
    {
        yield return new TannuraPreparata(_tannuraId);
    }
}