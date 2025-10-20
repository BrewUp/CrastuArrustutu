using CrastuArrustutu.Tannura.SharedKernel.CustomTypes;
using Muflone.Messages.Events;

namespace CrastuArrustutu.Tannura.ReadModel.EventHandlers;

public sealed class TannuraPreparataEventHandler(TannuraId aggregateId) : DomainEvent(aggregateId)
{
}