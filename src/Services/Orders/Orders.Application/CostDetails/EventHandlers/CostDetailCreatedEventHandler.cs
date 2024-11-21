
using Orders.Domain.Events;

namespace Orders.Application.CostDetails.EventHandlers;

public class CostDetailCreatedEventHandler(ILogger<CostDetailCreatedEventHandler> logger)
    : INotificationHandler<CostDetailCreatedEvent>
{
    public Task Handle(CostDetailCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}