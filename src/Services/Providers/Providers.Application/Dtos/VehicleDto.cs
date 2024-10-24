using Providers.Domain.Models;

namespace Providers.Application.Dtos;

public record VehicleDto(
    Guid Id, 
    VehicleType Type, 
    string Brand, 
    string Model, 
    int Year);
