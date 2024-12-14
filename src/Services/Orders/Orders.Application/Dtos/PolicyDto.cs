
namespace Orders.Application.Dtos;

public record PolicyDto(
        Guid Id,
        string Name,
        int AmountCovered,
        PriceDto Price,
        FeeDto Fees
    );
