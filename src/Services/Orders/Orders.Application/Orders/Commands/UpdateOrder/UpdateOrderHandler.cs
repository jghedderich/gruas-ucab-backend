
using Orders.Application.Exceptions;

namespace Orders.Application.Orders.Commands.UpdateOrder;

public class UpdateOrderHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateOrderCommand, UpdateOrderResult>
{
    public async Task<UpdateOrderResult> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
    {
        var orderId = command.Order.Id;
        var order = await dbContext.Orders
            .FindAsync([orderId], cancellationToken: cancellationToken);

        if (order == null)
        {
            throw new OrderNotFoundException(command.Order.Id);
        }

        UpdateOrderWithNewValues(order, command.Order);

        dbContext.Orders.Update(order);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateOrderResult(true);
    }

    public static void UpdateOrderWithNewValues(Order order, OrderDto orderDto)
    {
        // Client
        var updatedName = orderDto.Client.Name;
        var updatedEmail = orderDto.Client.Email;
        var updatedDniType = orderDto.Client.Dni.ToDniType();
        var updatedNumber = orderDto.Client.Dni.Number;
        var updatedPhone = orderDto.Client.Phone;
        var updatedClientVehicle = orderDto.Client.ClientVehicle;
        var updatedStatus = orderDto.OrderStatus;
        var updatedIncidentAddress = orderDto.IncidentAddress;
        var updatedDestinationAddres = orderDto.DestinationAddress;
        var vehicleType = Enum.Parse<VehicleType>(updatedClientVehicle.Type, true);


        order.Update(
            client: Client.Of(Name.Of(updatedName.FirstName,updatedName.LastName),Dni.Of(updatedDniType,updatedNumber),Phone.Of(updatedPhone),Email.Of(updatedEmail), ClientVehicle.Of(updatedClientVehicle.Brand, updatedClientVehicle.Model, updatedClientVehicle.Year, vehicleType)),
            incidentAddress: Address.Of(updatedIncidentAddress.AddressLine1,updatedIncidentAddress.AddressLine2,
            updatedIncidentAddress.City,updatedIncidentAddress.State,updatedIncidentAddress.Zip),
            destinationAddress: Address.Of(updatedDestinationAddres.AddressLine1, updatedDestinationAddres.AddressLine2,
            updatedDestinationAddres.City, updatedDestinationAddres.State, updatedDestinationAddres.Zip)
            );
    }
}