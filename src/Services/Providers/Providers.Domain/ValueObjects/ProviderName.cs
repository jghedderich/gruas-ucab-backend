namespace Providers.Domain.ValueObjects;

public record ProviderName
{
    public string FirstName { get; } = default!;
    public string LastName { get; } = default!;

}
