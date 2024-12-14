
namespace Providers.Application.Dtos;

public record ProviderDto(
    Guid Id,
    NameDto Name,
    string Phone,
    string? Email,
    string? Password,
    DniDto Dni,
    CompanyDto Company,
    List<VehicleDto> Vehicles,
    List<DriverDto> Drivers,
    bool? IsActive
    );
