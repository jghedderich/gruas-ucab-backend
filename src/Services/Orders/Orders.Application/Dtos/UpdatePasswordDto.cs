namespace Orders.Application.Dtos;

public record UpdatePasswordDto(
    Guid Id,
    string Password,
    string NewPassword
    );
