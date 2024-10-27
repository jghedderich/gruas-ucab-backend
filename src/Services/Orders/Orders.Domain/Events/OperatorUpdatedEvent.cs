namespace Orders.Domain.Events;

public record OperatorUpdatedEvent(Operator Operator) : IDomainEvent;
