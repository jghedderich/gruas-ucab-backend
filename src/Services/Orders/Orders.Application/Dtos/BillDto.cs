
namespace Orders.Application.Dtos;

public record BillDto(
        decimal BaseFee,
        decimal CostPerKm,
        decimal Subtotal,
        decimal Total,
        decimal Coverage
    );
