
namespace Orders.Application.Dtos;

public record OrderProgressDto(
    Guid Id, 
    string OrderStatus, 
    string Latitude,
    string Longitude,
    string Zip,
    string City,
    string State,
    string AddressLine1,
    string AddressLine2
    );
