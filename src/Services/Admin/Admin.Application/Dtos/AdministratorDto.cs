namespace Admin.Application.Dtos;

public record AdministratorDto(
    Guid Id,
    string Name,
    string Email,
    string Password
    
);

