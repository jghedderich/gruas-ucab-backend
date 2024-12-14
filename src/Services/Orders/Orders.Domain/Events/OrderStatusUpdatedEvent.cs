namespace Orders.Domain.Events;

public record OrderStatusUpdatedEvent(Order Order) : IDomainEvent;
