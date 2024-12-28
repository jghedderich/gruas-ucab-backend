
namespace Providers.Application.Dtos;

public record UpdateOrderStatusDto
(
    Guid Id,
    Guid DriverId,
    string Status,
    LocationDto? Location
);
