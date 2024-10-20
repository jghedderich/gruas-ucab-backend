
namespace Providers.Domain.ValueObjects;

public record DriverName
{
    public string FirstName { get; } = default!;
    public string LastName { get; } = default!;
    private DriverName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public static DriverName Of(string firstName, string lastName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(firstName);
        ArgumentException.ThrowIfNullOrWhiteSpace(lastName);
        
        return new DriverName(firstName, lastName);
    }
}
