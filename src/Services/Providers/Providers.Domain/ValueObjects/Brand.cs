
namespace Providers.Domain.ValueObjects;

public record Brand
{
    private const int DefaultLength = 5;
    public string Value { get; } = default!;
    private Brand(string value) => Value = value;

    public static Brand Of(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        ArgumentOutOfRangeException.ThrowIfNotEqual(value.Length, DefaultLength);
        
        return new Brand(value);
    }
}
