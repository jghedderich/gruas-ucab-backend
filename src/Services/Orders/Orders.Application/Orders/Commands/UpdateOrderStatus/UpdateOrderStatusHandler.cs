using Orders.Application.Exceptions;

namespace Orders.Application.Orders.Commands.UpdateOrderStatus;

public class UpdateOrderStatusHandlerI(IApplicationDbContext dbContext)
    : ICommandHandler<UpdateOrderStatusCommand, UpdateOrderStatusResult>
{
    public async Task<UpdateOrderStatusResult> Handle(UpdateOrderStatusCommand command, CancellationToken cancellationToken)
    {
        var orderId = command.Order.Id;
        var status = command.Order.OrderStatus;
        var order = await dbContext.Orders
            .FindAsync([orderId], cancellationToken: cancellationToken) ?? throw new OrderNotFoundException(command.Order.Id);


        UpdateOrderStatus(order, status);

        dbContext.Orders.Update(order);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateOrderStatusResult(true);
    }

    public static void UpdateOrderStatus(Order order, string status)
    {
        if (Enum.TryParse<Status>(status, out Status statusEnum))
        {
            order.UpdateStatus(OrderStatus.Of(statusEnum));
        }

    }
}
