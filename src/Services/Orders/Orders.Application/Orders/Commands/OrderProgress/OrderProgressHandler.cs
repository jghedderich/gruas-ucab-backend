

using BuildingBlocks.Messaging.Events;
using MassTransit;
using Orders.Application.Exceptions;
using Orders.Application.Orders.Commands.OrderProgress;

namespace Orders.Application.Orders.Commands.DriverProgress;

public class OrderProgressHandler(IApplicationDbContext dbContext, IPublishEndpoint publishEndpoint)
    : ICommandHandler<OrderProgressCommand, OrderProgressResult>
{
    public async Task<OrderProgressResult> Handle(OrderProgressCommand command, CancellationToken cancellationToken)
    {
        var orderId = command.Order.Id;
        var status = command.Order.OrderStatus;
        var order = await dbContext.Orders
            .FindAsync([orderId], cancellationToken: cancellationToken) ?? throw new OrderNotFoundException(command.Order.Id);

        UpdateOrderProgress(order, status);

        dbContext.Orders.Update(order);
        await dbContext.SaveChangesAsync(cancellationToken);

        var eventMessage = new OrderProgressUpdatedEvent
        {
            OrderId = command.Order.Id,
            DriverId = order.DriverId,
            Status = status,
            Latitude = command.Order.Latitude,
            Longitude = command.Order.Longitude,
            Zip = command.Order.Zip,
            City = command.Order.City,
            State = command.Order.State,
            AddressLine1 = command.Order.AddressLine1,
            AddressLine2 = command.Order.AddressLine2, 
        };

        await publishEndpoint.Publish(eventMessage, cancellationToken);

        return new OrderProgressResult(true, command.Order.OrderStatus);
    }

    public static void UpdateOrderProgress(Order order, string status)
    {
        if (Enum.TryParse<Status>(status, out Status statusEnum))
        {
            order.UpdateStatus(OrderStatus.Of(statusEnum));
        }

    }
}
