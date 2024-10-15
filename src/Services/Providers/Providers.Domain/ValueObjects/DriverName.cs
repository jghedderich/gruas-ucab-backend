
namespace Providers.Domain.ValueObjects;

public record DriverName
{
    private const int DefaultLength = 5;
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
        ArgumentOutOfRangeException.ThrowIfNotEqual(firstName.Length, DefaultLength);
        ArgumentOutOfRangeException.ThrowIfNotEqual(lastName.Length, DefaultLength);
        
        return new DriverName(firstName, lastName);
    }
}
