namespace Providers.Domain.ValueObjects;

public record Model
{
    public string Value { get; } = default!;
    private Model(string value) => Value = value;

    public static Model Of(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        
        return new Model(value);
    }
}
