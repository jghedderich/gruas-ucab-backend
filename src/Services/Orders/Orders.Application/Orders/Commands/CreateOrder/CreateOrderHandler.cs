


using Orders.Application.Exceptions;
using Orders.Application.Maps;

namespace Orders.Application.Orders.Commands.CreateOrder;

public class CreateOrderHandler(IApplicationDbContext dbContext, GoogleMapsService mapService) : ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
    public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        Policy policy = await dbContext.Policies
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id.Equals(command.Order.PolicyId), cancellationToken)
                ?? throw new PolicyNotFoundException(command.Order.PolicyId);

        var order = await CreateNewOrder(command.Order, policy);

        dbContext.Orders.Add(order);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateOrderResult(order.Id);
    }

    private async Task<Order> CreateNewOrder(OrderDto orderDto, Policy policy)
    {
        var dniType = orderDto.Client.Dni.ToDniType();

        var dni = Dni.Of(dniType, orderDto.Client.Dni.Number);

        var vehicleType = Enum.Parse<VehicleType>(orderDto.Client.ClientVehicle.Type, true);

        var status = Enum.Parse<Status>("ToBeAccepted", true);

        // Await the distance calculation
        var distance = await mapService.GetDistanceAsync(orderDto.IncidentAddress.Coordinates, orderDto.DestinationAddress.Coordinates);

        // Convert the distance from double to decimal
        decimal distanceDecimal = Convert.ToDecimal(distance);

        // Calculate the bill using the converted distance
        var bill = Bill.Of(policy.Fees.BaseFee, policy.Fees.PerKm * distanceDecimal, policy.AmountCovered);

        var newOrder = Order.Create(
                id: Guid.NewGuid(),
                operatorId: orderDto.OperatorId,
                policyId: orderDto.PolicyId,    
                client: Client.Of(Name.Of(orderDto.Client.Name.FirstName, orderDto.Client.Name.LastName),dni,Phone.Of(orderDto.Client.Phone),Email.Of(orderDto.Client.Email),ClientVehicle.Of(orderDto.Client.ClientVehicle.Brand,orderDto.Client.ClientVehicle.Model,
                orderDto.Client.ClientVehicle.Year, vehicleType)),
                orderStatus: OrderStatus.Of(status),
                incidentAddress: Address.Of(orderDto.IncidentAddress.AddressLine1,orderDto.IncidentAddress.AddressLine2,orderDto.IncidentAddress.City,orderDto.IncidentAddress.State,orderDto.IncidentAddress.Zip, Coordinates.Of(orderDto.IncidentAddress.Coordinates.Latitude,orderDto.IncidentAddress.Coordinates.Longitude)),
                destinationAddress: Address.Of(orderDto.DestinationAddress.AddressLine1, orderDto.DestinationAddress.AddressLine2, orderDto.DestinationAddress.City, orderDto.DestinationAddress.State, orderDto.DestinationAddress.Zip, Coordinates.Of(orderDto.DestinationAddress.Coordinates.Latitude, orderDto.DestinationAddress.Coordinates.Longitude)),
                driverId: orderDto.DriverId,
                bill: bill
            );

        return newOrder;
    }


}

