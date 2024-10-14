
namespace Providers.Domain.ValueObjects;

public record VehicleId
{
    public Guid Value { get; }
    private VehicleId(Guid value) => Value = value;
    public static VehicleId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("VehicleId cannot be empty.");
        }

        return new VehicleId(value);
    }
}
