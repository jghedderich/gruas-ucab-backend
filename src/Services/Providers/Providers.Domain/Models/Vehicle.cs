namespace Providers.Domain.Models;


public class Vehicle : Aggregate<VehicleId>
{

    public Brand Brand { get; private set; } = default!;
    public Model Model { get; private set; } = default!;
    public int Year { get; private set; } = default!;
    public VehicleType Type { get; private set; }
    
    public static Vehicle Create
        (VehicleId id, VehicleType type, Brand brand, Model model, int year)
    {
        var vehicle = new Vehicle
        {
            Id = id,
            Type = type,
            Brand = brand,
            Model = model,
            Year = year
        };

        vehicle.AddDomainEvent(new VehicleCreatedEvent(vehicle));

        return vehicle;
    }

    public void Update(VehicleType type, Brand brand, Model model, int year)
    {

        Type = type;
        Brand = brand;
        Model = model;
        Year = year;

        AddDomainEvent(new VehicleUpdatedEvent(this));
    }
}

public enum VehicleType
{
    Light,
    Medium,
    Heavy,
    Motorcycle
}