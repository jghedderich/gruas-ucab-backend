
namespace Orders.Application.Dtos;

public record ClientDto(
        NameDto Name,
        DniDto Dni,
        string Phone,
        string Email,
        ClientVehicleDto ClientVehicle
    );