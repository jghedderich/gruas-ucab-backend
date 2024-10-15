namespace Providers.Domain.ValueObjects;

public record Phone
{
    private const int DefaultLength = 11;
    public string Value { get; } = default!;
    private Phone(string value) => Value = value;

    public static Phone Of(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        ArgumentOutOfRangeException.ThrowIfNotEqual(value.Length, DefaultLength);
        
        return new Phone(value);
    }
}
