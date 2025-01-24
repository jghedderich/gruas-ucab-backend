
namespace Admin.Tests;

public static class AdministratorDtoHelper
{
    public static AdministratorDto CreateAdministratorDto(Guid id, string firstName, string lastName, string? email, string password)
    {
        return new AdministratorDto(
            Id: id,
            Name: new NameDto(firstName, lastName),
            Email: email,
            Password: password
        );
    }
}
