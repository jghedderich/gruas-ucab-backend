
namespace Providers.Application.Dtos;

public record ProviderDto(
    Guid Id,
    NameDto Name,
    string Phone,
    string Email,
    DniDto Dni,
    CompanyDto Company,
    List<VehicleDto> Vehicles,
    List<DriverDto> Drivers);
