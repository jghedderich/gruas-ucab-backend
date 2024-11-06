
namespace Orders.Application.Dtos;

public record PolicyDto(
        string Name,
        int AmountCovered,
        PriceDto Price,
        FeeDto Fees
    );
