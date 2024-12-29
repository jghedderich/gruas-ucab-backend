
namespace Orders.Application.Dtos;

public record CostDetailDto(
        Guid Id,
        Guid OrderId,
        string Description,
        decimal Amount,
        string StatusC
    );
