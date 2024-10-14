namespace Providers.Domain.ValueObjects;

public record Company
{
    public string Name { get; } = default!;
    public string Description { get; } = default!;
}
