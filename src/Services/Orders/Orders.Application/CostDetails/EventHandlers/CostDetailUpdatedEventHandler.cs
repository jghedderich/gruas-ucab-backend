
using Orders.Domain.Events;

namespace Orders.Application.CostDetails.EventHandlers;

public class CostDetailUpdatedEventHandler(ILogger<CostDetailUpdatedEventHandler> logger)
    : INotificationHandler<CostDetailUpdatedEvent>
{
    public Task Handle(CostDetailUpdatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}