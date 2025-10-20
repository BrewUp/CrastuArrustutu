using CrastuArrustutu.Tannura.SharedKernel.CustomTypes;
using Muflone.Messages.Events;

namespace CrastuArrustutu.Tannura.SharedKernel.Messages.Events;

public sealed class TannuraPreparata(TannuraId aggregateId) : DomainEvent(aggregateId)
{
}