
namespace Orders.Application.Operators.EventHandlers;

public class OperatorCreatedEventHandler(ILogger<OperatorCreatedEventHandler> logger)
    : INotificationHandler<OperatorCreatedEvent>
{
    public Task Handle(OperatorCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}
