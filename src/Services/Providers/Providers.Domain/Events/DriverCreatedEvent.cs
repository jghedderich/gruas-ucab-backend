namespace Providers.Domain.Events;

public record DriverCreatedEvent(Driver Driver): IDomainEvent;
