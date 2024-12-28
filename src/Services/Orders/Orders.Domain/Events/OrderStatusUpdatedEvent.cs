namespace Orders.Domain.Events;

public record OrderStatusUpdatedEvent(Guid Id, OrderStatus OrderStatus) : IDomainEvent;
