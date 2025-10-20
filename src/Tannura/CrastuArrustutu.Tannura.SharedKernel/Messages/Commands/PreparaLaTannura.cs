using CrastuArrustutu.Tannura.SharedKernel.CustomTypes;
using Muflone.Messages.Commands;

namespace CrastuArrustutu.Tannura.SharedKernel.Messages.Commands;

public sealed class PreparaLaTannura(TannuraId aggregateId) : Command(aggregateId)
{
}