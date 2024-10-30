namespace Orders.Domain.Events;

public record OrderUpdatedEvent(Order Order) : IDomainEvent;
