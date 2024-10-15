namespace Providers.Domain.Events;

public record VehicleUpdatedEvent(Vehicle Vehicle): IDomainEvent;
