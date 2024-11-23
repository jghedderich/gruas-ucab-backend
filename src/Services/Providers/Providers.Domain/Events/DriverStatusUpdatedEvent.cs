namespace Providers.Domain.Events;

public record DriverStatusUpdatedEvent(DriverName DriverName, Status Status): IDomainEvent;
