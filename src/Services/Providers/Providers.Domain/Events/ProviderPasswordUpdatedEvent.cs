namespace Providers.Domain.Events;

public record ProviderPasswordUpdatedEvent(ProviderName ProviderName, Password Password): IDomainEvent;
