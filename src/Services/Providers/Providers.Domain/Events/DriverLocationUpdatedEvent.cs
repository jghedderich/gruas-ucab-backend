namespace Providers.Domain.Events;

public record DriverLocationUpdatedEvent(Guid Id, Location Location): IDomainEvent;
