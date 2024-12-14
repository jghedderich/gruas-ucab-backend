

namespace Orders.Application.Dtos;

public record FeeDto(
        int BaseFee,
        int PerKm
    );