namespace Providers.Domain.Models;

public class Driver : Aggregate<Guid>
{
    public Guid ProviderId { get; private set; } = default!;
    public Guid VehicleId { get; private set; } = default!;
    public DriverName DriverName { get; private set; } = default!;
    public Email Email { get; private set; } = default!;
    public Password Password { get; private set; } = default!;
    public Phone Phone { get; private set; } = default!;
    public Dni Dni { get; private set; } = default!;
    public Status Status { get; private set; } = default!;
    public Location? Location { get; private set; } 

    public static Driver Create(
        Guid id,
        DriverName driverName,
        Guid providerId,
        Guid vehicleId,
        Email email,
        Password password,
        Phone phone,
        Dni dni,
        Status status,
        Location? location = null
     )
    {
        var driver = new Driver
        {
            Id = id,
            DriverName = driverName,
            ProviderId = providerId,
            VehicleId = vehicleId,
            Email = email,
            Password = password,
            Phone = phone,
            Dni = dni,
            Status = status,
            Location = location
        };

        driver.AddDomainEvent(new DriverCreatedEvent(driver));

        return driver;
    }

    public void Update(Guid vehicleId, Guid providerId, DriverName driverName, Dni dni, Phone phone)
    {
        VehicleId = vehicleId;
        ProviderId = providerId;
        DriverName = driverName;
        Phone = phone;
        Dni = dni;

        AddDomainEvent(new DriverUpdatedEvent(this));
    }

    public void UpdatePassword(Password password)
    {
        Password = password;
        AddDomainEvent(new DriverUpdatedEvent(this));
    }

    public void UpdateStatus(Status status)
    {
        Status = status;
        AddDomainEvent(new DriverStatusUpdatedEvent(Id, status));
    }

    public void UpdateLocation(Location location)
    {
        Location = location;
        AddDomainEvent(new DriverLocationUpdatedEvent(Id, location));
    }
}

public enum Status
{
    Available,
    Unavailable
}