namespace Orders.Domain.Events;

public record PolicyUpdatedEvent(Policy Policy) : IDomainEvent;