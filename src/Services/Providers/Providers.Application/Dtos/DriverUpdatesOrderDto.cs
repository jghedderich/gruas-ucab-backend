
namespace Providers.Application.Dtos;

public record DriverUpdatesOrderDto(
    Guid OrderId,
    Guid DriverId,
    LocationDto? Location
);
