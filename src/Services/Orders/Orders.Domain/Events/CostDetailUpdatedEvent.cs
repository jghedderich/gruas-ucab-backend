namespace Orders.Domain.Events;

public record CostDetailUpdatedEvent(CostDetail CostDetail) : IDomainEvent;
