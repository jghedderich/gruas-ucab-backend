namespace Providers.Domain.Events;

public record ProviderUpdatedEvent(Provider Provider): IDomainEvent;
