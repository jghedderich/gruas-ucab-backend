namespace Providers.Domain.ValueObjects;

public record ProviderName
{
    private const int DefaultLength = 2;
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
        
        return new ProviderName(firstName, lastName);
    }
}
