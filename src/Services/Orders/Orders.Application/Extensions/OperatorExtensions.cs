

using System.Linq;

namespace Orders.Application.Extensions;

public static class OperatorExtensions
{
    public static IEnumerable<OperatorDto> ToOperatorDtoList(this IEnumerable<Operator> operators)
    {
        return operators.Select(o => new OperatorDto(
                Id: o.Id,
                Name: new NameDto(o.OperatorName.FirstName, o.OperatorName.LastName),
                Email: o.Email.Value,
                Phone: o.Phone.Value,
                Dni: new DniDto(Type: o.Dni.Type.ToString(), Number: o.Dni.Number),
                Password: o.Password.Value,
                Orders: o.Orders.Select(or => new OrderDto(or.Id, or.OperatorId, or.PolicyId,
                new ClientDto(new NameDto(or.Client.Name.FirstName, or.Client.Name.LastName),
                new DniDto(Type: or.Client.Dni.Type.ToString(), Number: or.Client.Dni.Number),
                or.Client.Phone.Value, or.Client.Email.Value,
                new ClientVehicleDto(or.Client.ClientVehicle.Brand, or.Client.ClientVehicle.Model, or.Client.ClientVehicle.Year, or.Client.ClientVehicle.TypeV.ToString())), or.OrderStatus.ToString(),
                new AddressDto(or.IncidentAddress.AddressLine1, or.IncidentAddress.AddressLine2, or.IncidentAddress.City, or.IncidentAddress.State, or.IncidentAddress.Zip),
                new AddressDto(or.DestinationAddress.AddressLine1, or.DestinationAddress.AddressLine2, or.DestinationAddress.City, or.DestinationAddress.State, or.DestinationAddress.Zip),
                CostDetails: or.CostDetails.Select(c => new CostDetailDto(c.Id, c.OrderId, c.Description, c.Amount, c.IsApproved)).ToList()
            )).ToList()));
    }

    public static OperatorDto ToOperatorDto(this Operator operatorN)
    {
        return DtoFromOperator(operatorN);
    }

    private static OperatorDto DtoFromOperator(Operator operatorN)
    {
        return new OperatorDto(
                Id: operatorN.Id,
                Name: new NameDto(operatorN.OperatorName.FirstName, operatorN.OperatorName.LastName),
                Email: operatorN.Email.Value,
                Phone: operatorN.Phone.Value,
                Dni: new DniDto(operatorN.Dni.Type.ToString(),operatorN.Dni.Number),
                Password: operatorN.Password.Value,
                Orders: operatorN.Orders.Select(or => new OrderDto(or.Id, or.OperatorId, or.PolicyId,
                new ClientDto(new NameDto(or.Client.Name.FirstName, or.Client.Name.LastName),
                new DniDto(Type: or.Client.Dni.Type.ToString(), Number: or.Client.Dni.Number),
                or.Client.Phone.Value, or.Client.Email.Value,
                new ClientVehicleDto(or.Client.ClientVehicle.Brand, or.Client.ClientVehicle.Model, or.Client.ClientVehicle.Year, or.Client.ClientVehicle.TypeV.ToString())), or.OrderStatus.ToString(),
                new AddressDto(or.IncidentAddress.AddressLine1, or.IncidentAddress.AddressLine2, or.IncidentAddress.City, or.IncidentAddress.State, or.IncidentAddress.Zip),
                new AddressDto(or.DestinationAddress.AddressLine1, or.DestinationAddress.AddressLine2, or.DestinationAddress.City, or.DestinationAddress.State, or.DestinationAddress.Zip),
                CostDetails: or.CostDetails.Select(c => new CostDetailDto(c.Id, c.OrderId, c.Description, c.Amount, c.IsApproved)).ToList()
            )).ToList());    
    }
}