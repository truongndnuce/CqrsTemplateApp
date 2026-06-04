using DemoCICD.Contract.Abstractions.Message;

namespace Contract.Service.V2.Product;

public static class DomainEvent
{
    public record ProductCreated(Guid Id) : IDomainEvent;
    public record ProductDeleted(Guid Id) : IDomainEvent;
    public record ProductUpdated(Guid Id) : IDomainEvent;
}
