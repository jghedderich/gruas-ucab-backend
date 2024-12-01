
namespace Providers.Application.Dtos;

public record LocationDto
(
    string Address1,
    string? Address2,
    string Zip,
    string State,
    string City,
    CoordinatesDto Coordinates
);
