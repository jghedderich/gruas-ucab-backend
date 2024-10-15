
namespace Providers.Domain.ValueObjects;

public record Dni 
{
    private const int DniNumberLength = 7;
    public string Number { get; } = default!;
    public DniType Type { get; } = default!;
    private Dni(DniType type, string number)
    {
        Type = type;
        Number = number;
    }

    public static Dni Of(DniType type, string number)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(type.ToString());
        ArgumentException.ThrowIfNullOrWhiteSpace(number);
        ArgumentOutOfRangeException.ThrowIfLessThan(number.Length, DniNumberLength);
        
        return new Dni(type, number);
    }
}
public enum DniType
{
    V,
    J,
    E
}
