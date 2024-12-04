

namespace Orders.Application.Orders.Commands.CreateOrder;

public class CreateOrderHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
    public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {

        var order = CreateNewOrder(command.Order);

        dbContext.Orders.Add(order);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateOrderResult(order.Id);
    }

    private static Order CreateNewOrder(OrderDto orderDto)
    {
        var dniType = orderDto.Client.Dni.ToDniType();

        var dni = Dni.Of(dniType, orderDto.Client.Dni.Number);

        var vehicleType = Enum.Parse<VehicleType>(orderDto.Client.ClientVehicle.Type, true);

        var status = Enum.Parse<Status>(orderDto.OrderStatus, true);


        var newOrder = Order.Create(
                id: Guid.NewGuid(),
                operatorId: orderDto.OperatorId,
                policyId: orderDto.PolicyId,    
                client: Client.Of(Name.Of(orderDto.Client.Name.FirstName, orderDto.Client.Name.LastName),dni,Phone.Of(orderDto.Client.Phone),Email.Of(orderDto.Client.Email),ClientVehicle.Of(orderDto.Client.ClientVehicle.Brand,orderDto.Client.ClientVehicle.Model,
                orderDto.Client.ClientVehicle.Year, vehicleType)),
                orderStatus: OrderStatus.Of(status),
                incidentAddress: Address.Of(orderDto.IncidentAddress.AddressLine1,orderDto.IncidentAddress.AddressLine2,orderDto.IncidentAddress.City,orderDto.IncidentAddress.State,orderDto.IncidentAddress.Zip, orderDto.IncidentAddress.Latitud, orderDto.IncidentAddress.Longitud),
                destinationAddress: Address.Of(orderDto.DestinationAddress.AddressLine1, orderDto.DestinationAddress.AddressLine2, orderDto.DestinationAddress.City, orderDto.DestinationAddress.State, orderDto.DestinationAddress.Zip, orderDto.DestinationAddress.Latitud, orderDto.DestinationAddress.Longitud),
                driverId: orderDto.DriverId
            );

        return newOrder;
    }


}

