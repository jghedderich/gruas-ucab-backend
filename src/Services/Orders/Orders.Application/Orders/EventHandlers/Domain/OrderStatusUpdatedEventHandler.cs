using MassTransit;

namespace Orders.Application.Orders.EventHandlers.Domain;
public class OrderStatusUpdatedEventHandler
    (IPublishEndpoint publishEndpoint, ILogger<OrderStatusUpdatedEventHandler> logger)
    : INotificationHandler<OrderStatusUpdatedEvent>
{
    public async Task Handle(OrderStatusUpdatedEvent domainEvent, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", domainEvent.GetType().Name);

        var orderStatusUpdatedIntegrationEvent = new UpdateStatusDto(domainEvent.Id, domainEvent.OrderStatus.ToString());

        await publishEndpoint.Publish(orderStatusUpdatedIntegrationEvent, cancellationToken);
    }
}
