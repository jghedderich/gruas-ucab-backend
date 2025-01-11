namespace Providers.Domain.Models;

public class Vehicle : Aggregate<Guid>
{
    
    public Guid ProviderId { get; private set; } = default!;
    public Brand Brand { get; private set; } = default!;
    public Model Model { get; private set; } = default!;
    public string LicensePlate { get; private set; } = default!;
    public string Color { get; private set; } = default!;
    public int Year { get; private set; } = default!;
    public VehicleType Type { get; private set; } = default!;

    public static Vehicle Create(
        Guid id,
        Guid providerId,
        VehicleType type, 
        Brand brand, 
        Model model,
        string licensePlate,
        string color,
        int year)
    {
        var vehicle = new Vehicle
        {
            Id = id,
            ProviderId = providerId,
            Type = type,
            Brand = brand,
            Model = model,
            Year = year,
            LicensePlate = licensePlate,
            Color = color
        };

        vehicle.AddDomainEvent(new VehicleCreatedEvent(vehicle));

        return vehicle;

    }

    public void Update(VehicleType type, Brand brand, Model model, int year, string licensePlate, string color)
    {
        Type = type;
        Brand = brand;
        Model = model;
        Year = year;
        LicensePlate = licensePlate;
        Color = color;

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