
namespace Providers.Application.Dtos;

public record UpdateLocationDto
(
    Guid DriverId,
    string Address1,
    string? Address2,
    string Zip,
    string State,
    string City,
    CoordinatesDto Coordinates
);
