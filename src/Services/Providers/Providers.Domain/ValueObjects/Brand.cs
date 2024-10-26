
namespace Providers.Domain.ValueObjects;

public record Brand
{
    public string Value { get; } = default!;
    private Brand(string value) => Value = value;

    public static Brand Of(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        
        return new Brand(value);
    }
}
