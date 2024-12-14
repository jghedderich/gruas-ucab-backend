namespace Orders.Domain.Events;
public record CostDetailCreatedEvent(CostDetail CostDetail) : IDomainEvent;