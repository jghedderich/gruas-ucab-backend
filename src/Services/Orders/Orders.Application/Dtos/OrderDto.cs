

namespace Orders.Application.Dtos;

public record OrderDto(
        Guid Id,
        Guid OperatorId,
        Guid PolicyId,
        Guid DriverId,
        ClientDto Client,
        string OrderStatus,
        AddressDto IncidentAddress,
        AddressDto DestinationAddress,
        List<CostDetailDto>? CostDetails,
        BillDto? Bill,
        bool? IsActive
    );
