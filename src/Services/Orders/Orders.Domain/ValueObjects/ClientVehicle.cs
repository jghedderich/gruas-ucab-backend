namespace Orders.Domain.ValueObjects;

public record ClientVehicle
{
    public string Brand { get; } = default!;
    public string Model { get; } = default!;
    public int Year { get; } = default!;
    public VehicleType Type { get; } = default!;

}

public enum VehicleType
{
    Suv,
    Sedan,
    Pickup,
    Motorcycle
}
