namespace Orders.Domain.Events;

public record OperatorCreatedEvent(Operator Operator) : IDomainEvent;
