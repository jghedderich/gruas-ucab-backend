
namespace Providers.Application.Dtos;

public record DriverDto(
    Guid Id, 
    Guid VehicleId, 
    NameDto Name, 
    DniDto Dni, 
    string Phone);
