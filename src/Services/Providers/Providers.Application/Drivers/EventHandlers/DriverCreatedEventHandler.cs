namespace Providers.Application.Providers.EventHandlers;

public class DriverCreatedEventHandler(ILogger<DriverCreatedEventHandler> logger) : INotificationHandler<DriverCreatedEvent>
{
    public Task Handle(DriverCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handler: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}