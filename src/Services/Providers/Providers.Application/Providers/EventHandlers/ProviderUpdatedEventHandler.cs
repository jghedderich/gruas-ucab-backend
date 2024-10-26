namespace Providers.Application.Providers.EventHandlers;

public class ProviderUpdatedEventHandler(ILogger<ProviderUpdatedEventHandler> logger)
    : INotificationHandler<ProviderUpdatedEvent>
{
    public Task Handle(ProviderUpdatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}
