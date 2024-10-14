
namespace Providers.Domain.Models;

public class Vehicle : Entity<VehicleId>
{
    public string Brand { get; private set; } = default!;
    public string Model { get; private set; } = default!;
    public int Year { get; private set; } = default!;

    public static Vehicle Create(VehicleId id,  string brand, string model, int year)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(brand);
        ArgumentException.ThrowIfNullOrWhiteSpace(model);

        var vehicle = new Vehicle
        {
            Id = id,
            Brand = brand,
            Model = model,
            Year = year,
        };

        return vehicle;
    }

}
