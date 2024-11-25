namespace Orders.Application.Policies.EventHandlers;
public class PolicyUpdatedEventHandler(ILogger<PolicyUpdatedEventHandler> logger)
    : INotificationHandler<PolicyUpdatedEvent>
{
    public Task Handle(PolicyUpdatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}
