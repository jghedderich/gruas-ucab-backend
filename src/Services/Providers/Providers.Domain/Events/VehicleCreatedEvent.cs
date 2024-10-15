namespace Providers.Domain.Events;

public record VehicleCreatedEvent(Vehicle Vehicle): IDomainEvent;
