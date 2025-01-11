
namespace Providers.Application.Dtos;

public record VehicleDto(
    Guid Id, 
    Guid ProviderId,
    string Type, 
    string Brand, 
    string Model, 
    int Year,
    string LicensePlate,
    string Color,
    bool? IsActive
    );
