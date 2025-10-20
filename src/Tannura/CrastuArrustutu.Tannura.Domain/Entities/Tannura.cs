using CrastuArrustutu.Tannura.SharedKernel.CustomTypes;
using CrastuArrustutu.Tannura.SharedKernel.Messages.Events;
using Muflone.Core;

namespace CrastuArrustutu.Tannura.Domain.Entities;

public class Tannura : AggregateRoot
{
    protected Tannura()
    {}
    
    internal static Tannura Create(TannuraId tannuraId)
    {
        return new Tannura(tannuraId);
    }

    private Tannura(TannuraId tannuraId)
    {
        RaiseEvent(new TannuraPreparata(tannuraId));
    }

    private void Apply(TannuraPreparata @event)
    {
        Id = @event.AggregateId;
    }
}