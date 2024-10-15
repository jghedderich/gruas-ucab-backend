namespace Providers.Domain.ValueObjects;

public record ProviderName
{
    private const int DefaultLength = 5;
    public string FirstName { get; } = default!;
    public string LastName { get; } = default!;

    private ProviderName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public static ProviderName Of(string firstName, string lastName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(firstName);
        ArgumentException.ThrowIfNullOrWhiteSpace(lastName);
        ArgumentOutOfRangeException.ThrowIfNotEqual(firstName.Length, DefaultLength);
        ArgumentOutOfRangeException.ThrowIfNotEqual(lastName.Length, DefaultLength);
        
        return new ProviderName(firstName, lastName);
    }
}
