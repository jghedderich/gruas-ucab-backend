using BuildingBlocks.Messaging.Events;
using MassTransit;
using Orders.Application.Orders.Commands.UpdateOrderStatus;

namespace Orders.Application.Orders.EventHandlers.Integration;

public class OrderUpdatedEventHandler 
    (ISender sender, ILogger<OrderUpdatedEventHandler> logger)
    : IConsumer<DriverUpdatesOrderEvent>
{
    public async Task Consume(ConsumeContext<DriverUpdatesOrderEvent> context)
    {
        // Update order status
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

        var command = MapToUpdateOrderStatusCommand(context.Message);
        await sender.Send(command);
    }

    private static UpdateOrderStatusCommand MapToUpdateOrderStatusCommand(DriverUpdatesOrderEvent message)
    {
        var updateStatusDto = new UpdateStatusDto(message.OrderId, message.Status);
        return new UpdateOrderStatusCommand(updateStatusDto);
    }
}
