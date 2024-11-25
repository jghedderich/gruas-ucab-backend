
namespace Orders.Application.Extensions;

public static class OrderExtensions
{
    public static IEnumerable<OrderDto> ToOrderDtoList(this IEnumerable<Order> orders)
    {
        return orders.Select(o => new OrderDto(
                Id: o.Id,
                OperatorId: o.OperatorId,
                PolicyId: o.PolicyId,
                Client: new ClientDto(new NameDto(o.Client.Name.FirstName, o.Client.Name.LastName),
                new DniDto(Type: o.Client.Dni.Type.ToString(), Number: o.Client.Dni.Number),
                o.Client.Phone.Value, o.Client.Email.Value,
                new ClientVehicleDto(o.Client.ClientVehicle.Brand, o.Client.ClientVehicle.Model, o.Client.ClientVehicle.Year, o.Client.ClientVehicle.TypeV.ToString())), o.OrderStatus.Status.ToString(),
                new AddressDto(o.IncidentAddress.AddressLine1, o.IncidentAddress.AddressLine2, o.IncidentAddress.City, o.IncidentAddress.State, o.IncidentAddress.Zip),
                new AddressDto(o.DestinationAddress.AddressLine1, o.DestinationAddress.AddressLine2, o.DestinationAddress.City, o.DestinationAddress.State, o.DestinationAddress.Zip),
                CostDetails: o.CostDetails.Select(c => new CostDetailDto(c.Id, c.OrderId, c.Description, c.Amount, c.IsApproved)).ToList(),
                IsActive: o.IsActive
            ));
    }

    public static OrderDto ToOrderDto(this Order order)
    {
        return DtoFromOrder(order);
    }

    private static OrderDto DtoFromOrder(Order order)
    {
        return new OrderDto(
                Id: order.Id,
                OperatorId: order.OperatorId,
                PolicyId: order.PolicyId,
                Client: new ClientDto(new NameDto(order.Client.Name.FirstName, order.Client.Name.LastName),
                new DniDto(Type: order.Client.Dni.Type.ToString(), Number: order.Client.Dni.Number),
                order.Client.Phone.Value, order.Client.Email.Value,
                new ClientVehicleDto(order.Client.ClientVehicle.Brand, order.Client.ClientVehicle.Model, order.Client.ClientVehicle.Year, order.Client.ClientVehicle.TypeV.ToString())), order.OrderStatus.Status.ToString(),
                new AddressDto(order.IncidentAddress.AddressLine1, order.IncidentAddress.AddressLine2, order.IncidentAddress.City, order.IncidentAddress.State, order.IncidentAddress.Zip),
                new AddressDto(order.DestinationAddress.AddressLine1, order.DestinationAddress.AddressLine2, order.DestinationAddress.City, order.DestinationAddress.State, order.DestinationAddress.Zip),
                CostDetails: order.CostDetails.Select(c => new CostDetailDto(c.Id, c.OrderId, c.Description, c.Amount, c.IsApproved)).ToList(),
                IsActive: order.IsActive
            );
    }
}
