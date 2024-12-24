
namespace Admin.Domain.ValueObjects;

public record AdministratorName
{
    public string FirstName { get; } = default!;
    public string LastName { get; } = default!;
    private AdministratorName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public static AdministratorName Of(string firstName, string lastName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(firstName);
        ArgumentException.ThrowIfNullOrWhiteSpace(lastName);
        
        return new AdministratorName(firstName, lastName);
    }
}
