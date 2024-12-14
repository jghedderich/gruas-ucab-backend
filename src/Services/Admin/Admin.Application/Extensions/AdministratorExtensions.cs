using Admin.Application.Dtos;
using Admin.Domain.Models;

namespace Admin.Application.Extensions;

public static class AdministratorExtensions
{
    public static IEnumerable<AdministratorDto> ToAdministratorDtoList(this IEnumerable<Administrator> administrators)
    {
        return administrators.Select(admin => new AdministratorDto(
            Id: admin.Id,
            Name: admin.Name,
            Email: admin.Email.Value,
            Password: admin.Password.Value
        ));
    }

    public static AdministratorDto ToAdministratorDto(this Administrator administrator)
    {
        return DtoFromAdministrator(administrator);
    }

    private static AdministratorDto DtoFromAdministrator(Administrator administrator)
    {
        return new AdministratorDto(
            Id: administrator.Id,
            Name: administrator.Name,
            Email: administrator.Email.Value,
            Password: administrator.Password.Value
        );
    }
}
