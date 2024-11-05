namespace Orders.Application.Operators.EventHandlers;

public class OperatorUpdatedEventHandler(ILogger<OperatorUpdatedEventHandler> logger)
    : INotificationHandler<OperatorUpdatedEvent>
{
    public Task Handle(OperatorUpdatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}
