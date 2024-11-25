

namespace Orders.Application.Dtos;

public record OrderDto(
        Guid Id,
        Guid OperatorId,
        Guid PolicyId,
        ClientDto Client,
        string OrderStatus,
        AddressDto IncidentAddress,
        AddressDto DestinationAddress,
        List<CostDetailDto>? CostDetails,
        bool? IsActive
    );
