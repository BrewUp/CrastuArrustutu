using CrastuArrustutu.Tannura.SharedKernel.CustomTypes;
using Muflone.Messages.Commands;

namespace CrastuArrustutu.Tannura.SharedKernel.Messages.Commands;

public sealed class PreparaLaLegna(TannuraId aggregateId, Legna legna) : Command(aggregateId)
{
    public Legna Legna { get; private set; } = legna;
}