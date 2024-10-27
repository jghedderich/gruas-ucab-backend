
namespace Providers.Application.Dtos;

public record VehicleDto(
    Guid Id, 
    string Type, 
    string Brand, 
    string Model, 
    int Year);
