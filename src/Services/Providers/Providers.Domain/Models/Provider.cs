
using Microsoft.VisualBasic;

namespace Providers.Domain.Models;

public class Provider : Aggregate<Guid>
{

    private readonly List<Driver> _drivers = [];
    public IReadOnlyList<Driver> Drivers => _drivers.AsReadOnly();

    private readonly List<Vehicle> _vehicles = [];
    public IReadOnlyList<Vehicle> Vehicles => _vehicles.AsReadOnly();
    public ProviderName ProviderName { get; private set; } = default!;
    public Email Email { get; private set; } = default!;
    public Phone Phone { get; private set; } = default!;
    public Dni Dni { get; private set; } = default!;
    public Company Company { get; private set; } = default!;

    public static Provider Create(
         Guid id,
         ProviderName providerName,
         Email email,
         Phone phone,
         Dni dni,
         Company company
     )
    {
        var provider = new Provider
        {
            Id = id,
            ProviderName = providerName,
            Email = email,
            Phone = phone,
            Dni = dni,
            Company = company
        };

        provider.AddDomainEvent(new ProviderCreatedEvent(provider));

        return provider;
    }
    public void Update(ProviderName providerName, Company company)
    {
        ProviderName = providerName;
        Company = company;

        AddDomainEvent(new ProviderUpdatedEvent(this));
    }

    public void AddDriver(Guid driverId, DriverName driverName, Guid providerId, Guid vehicleId, Email email, Phone phone, Dni dni)
    {
        var driver = Driver.Create(driverId, driverName,providerId, vehicleId, email, phone, dni);
        _drivers.Add(driver);
    }

    public void RemoveDriver(Guid driverId)
    {
        var driver = _drivers.FirstOrDefault(d => d.Id == driverId);
        if (driver != null)
        {
            _drivers.Remove(driver);
        }
    }

    public void AddVehicle(Guid vehicleId, VehicleType type, Brand brand, Model model, int year)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(year);

        var vehicle = Vehicle.Create(vehicleId, Id, type, brand, model, year);
        _vehicles.Add(vehicle);
    }
}
