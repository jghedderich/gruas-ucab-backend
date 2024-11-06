

namespace Orders.Application.Dtos;

public record ClientVehicleDto(
        string Brand,
        string Model,
        int Year,
        string Type
    );