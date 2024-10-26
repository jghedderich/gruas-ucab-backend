namespace Providers.Domain.Events;

public record ProviderCreatedEvent(Provider Provider): IDomainEvent;
