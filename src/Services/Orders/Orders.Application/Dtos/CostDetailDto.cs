
namespace Orders.Application.Dtos;

public record CostDetailDto(
        Guid Id,
        Guid OrderId,
        string Description,
        double Amount,
        bool IsApproved
    );
