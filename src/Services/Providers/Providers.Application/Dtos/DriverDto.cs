
namespace Providers.Application.Dtos;

public record DriverDto(
    Guid Id, 
    Guid VehicleId, 
    Guid ProviderId,
    NameDto Name, 
    DniDto Dni, 
    string Phone,
    string Email,
    string Password,
    StatusDto Status,
    bool? IsActive
    );
