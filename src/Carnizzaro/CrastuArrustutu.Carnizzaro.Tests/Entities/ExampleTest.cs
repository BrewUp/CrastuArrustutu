using Microsoft.Extensions.Logging.Abstractions;
using Muflone.Messages.Commands;
using Muflone.Messages.Events;
using Muflone.SpecificationTests;

namespace CrastuArrustutu.Carnizzaro.Tests.Entities;

public class OrderCreatePurchaseOrderSuccessful : CommandSpecification<CreatePurchaseOrder>
{
    protected override IEnumerable<DomainEvent> Given()
    {
        yield break;
    }

    protected override CreatePurchaseOrder When()
    {
        throw new NotImplementedException();
    }

    protected override ICommandHandlerAsync<CreatePurchaseOrder> OnHandler()
    {
        throw new NotImplementedException();
    }

    protected override IEnumerable<DomainEvent> Expect()
    {
        throw new NotImplementedException();
    }
}