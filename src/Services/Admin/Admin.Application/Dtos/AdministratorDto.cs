namespace Admin.Application.Dtos;

public record AdministratorDto(
    Guid Id,
    NameDto Name,
    string? Email,
    string Password
);

