namespace Providers.Domain.ValueObjects;

public record RIF
{
    public string Value { get; private init; }

    // Private parameterless constructor for EF Core
    private RIF() { }

    private RIF(string value) => Value = value;

    public static RIF Of(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new DomainException("RIF cannot be empty or whitespace.");
        }

        return new RIF(value);
    }

    public static implicit operator string(RIF rif) => rif.Value;

    public override string ToString() => Value;
}