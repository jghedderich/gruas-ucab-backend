
namespace Orders.Application.Dtos;

public record CostDetailDto(
        string Description,
        decimal Amount,
        bool IsApproved
    );
