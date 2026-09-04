using MediatR ;

namespace Contract.Abtractions.Message;

public interface IDomainEvent : INotification
{
    public Guid Id { get; init; }
}
