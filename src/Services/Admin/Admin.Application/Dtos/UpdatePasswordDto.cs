namespace Admin.Application.Dtos;

public record UpdatePasswordDto(
    Guid Id,
    string NewPassword
    );
