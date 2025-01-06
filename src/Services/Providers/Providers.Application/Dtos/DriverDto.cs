
namespace Providers.Application.Dtos;

public record DriverDto(
    Guid Id, 
    Guid VehicleId, 
    Guid ProviderId,
    NameDto Name, 
    DniDto Dni, 
    string? Phone,
    string? Email,
    string? Password,
    string? Status,
    LocationDto? Location,
    bool? IsActive,
    string? Token
    );
