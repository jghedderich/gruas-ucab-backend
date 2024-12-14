
namespace Orders.Domain.Events;


public record PolicyCreatedEvent(Policy Policy) : IDomainEvent;
