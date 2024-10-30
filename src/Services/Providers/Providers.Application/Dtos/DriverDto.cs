
namespace Providers.Application.Dtos;

public record DriverDto(
    Guid Id, 
    Guid VehicleId, 
    Guid ProviderId,
    NameDto Name, 
    DniDto Dni, 
    string Phone,
    string Email,
    bool? IsActive
    );
