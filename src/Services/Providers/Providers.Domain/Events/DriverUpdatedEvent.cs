namespace Providers.Domain.Events;

public record DriverUpdatedEvent(Driver Driver): IDomainEvent;
