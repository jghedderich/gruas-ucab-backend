namespace Orders.Application.Policies.EventHandlers;

public class PolicyCreatedEventHandler(ILogger<PolicyCreatedEventHandler> logger)
    : INotificationHandler<PolicyCreatedEvent>
{
    public Task Handle(PolicyCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}
