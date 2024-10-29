namespace Providers.Application.Drivers.EventHandlers;

public class DriverUpdatedEventHandler(ILogger<DriverUpdatedEventHandler> logger) : INotificationHandler<DriverUpdatedEvent>
{
    public Task Handle(DriverUpdatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handler: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}
