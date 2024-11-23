namespace Providers.Domain.Events;

public record DriverPasswordUpdatedEvent(DriverName DriverName, Password Password): IDomainEvent;
