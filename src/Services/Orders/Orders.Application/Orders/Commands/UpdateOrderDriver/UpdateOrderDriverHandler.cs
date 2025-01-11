
using BuildingBlocks.Messaging.Events;
using MassTransit;
using Orders.Application.Exceptions;

namespace Orders.Application.Orders.Commands.UpdateOrderDriver;

public class UpdateOrderDriverHandler(IApplicationDbContext dbContext, IPublishEndpoint publishEndpoint) : ICommandHandler<UpdateOrderDriverCommand, UpdateOrderDriverResult>
{
    public async Task<UpdateOrderDriverResult> Handle(UpdateOrderDriverCommand command, CancellationToken cancellationToken)
    {
        var orderId = command.Order.Id;
        var driverId = command.Order.DriverId;
        var order = await dbContext.Orders
            .FindAsync([orderId], cancellationToken: cancellationToken) ?? throw new OrderNotFoundException(command.Order.Id);

        UpdateOrderDriver(order, driverId);

        dbContext.Orders.Update(order);
        await dbContext.SaveChangesAsync(cancellationToken);

        var eventMessage = new DriverAssignedEvent
        {
            OrderId = command.Order.Id,
            DriverId = command.Order.DriverId
        };

        await publishEndpoint.Publish(eventMessage, cancellationToken);

        return new UpdateOrderDriverResult(true);
    }

    public static void UpdateOrderDriver(Order order, Guid driverId)
    {
        order.UpdateOrderDriver(driverId);
    }
}