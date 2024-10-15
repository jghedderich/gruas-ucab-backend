namespace Providers.Domain.ValueObjects;

public record Model
{
    private const int DefaultLength = 5;
    public string Value { get; } = default!;
    private Model(string value) => Value = value;

    public static Model Of(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        ArgumentOutOfRangeException.ThrowIfNotEqual(value.Length, DefaultLength);
        
        return new Model(value);
    }
}
