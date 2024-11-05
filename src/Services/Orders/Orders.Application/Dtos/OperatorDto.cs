
namespace Orders.Application.Dtos;

public record OperatorDto(
    Guid Id,
    NameDto Name,
    string Email,
    string Phone,
    DniDto Dni,
    List<OrderDto> Orders);


