
namespace Orders.Domain.ValueObjects;

public record Password
{
    public Password() { }

    private const int DefaultLength = 6;
    public string Value { get; } = default!;
    private Password(string value) => Value = value;

    public static Password Of(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        ArgumentOutOfRangeException.ThrowIfLessThan(value.Length, DefaultLength);

        return new Password(value);
    }
}
