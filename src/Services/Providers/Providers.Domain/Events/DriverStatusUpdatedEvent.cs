namespace Providers.Domain.Events;

public record DriverStatusUpdatedEvent(Guid Id, Status Status): IDomainEvent;
