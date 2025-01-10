
using Orders.Application.Exceptions;

namespace Orders.Application.Orders.Commands.UpdateOrderDriver;

public class UpdateOrderDriverHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateOrderDriverCommand, UpdateOrderDriverResult>
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

        return new UpdateOrderDriverResult(true);
    }

    public static void UpdateOrderDriver(Order order, Guid driverId)
    {
        order.UpdateOrderDriver(driverId);
        order.UpdateStatus(OrderStatus.Of(Status.ToBeAccepted));
    }
}