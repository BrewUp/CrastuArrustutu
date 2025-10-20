using CrastuArrustutu.Tannura.SharedKernel.CustomTypes;
using Muflone.Messages.Events;

namespace CrastuArrustutu.Tannura.SharedKernel.Messages.Events;

public sealed class LegnaPreparata(TannuraId aggregateId, Legna legna) : DomainEvent(aggregateId)
{
    public Legna Legna { get; private set; } = legna;
}