namespace Providers.Domain.ValueObjects;

public record DriverId 
{
    public Guid Value { get; set; }
    private DriverId(Guid value)
    {
        Value = value;
    }
    public static DriverId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("DriverId cannot be empty.");
        }

        return new DriverId(value);
    }
}
