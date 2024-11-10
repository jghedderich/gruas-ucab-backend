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

    
    public static Driver Create(
        Guid id,
        DriverName driverName, 
        Guid providerId,
        Guid vehicleId,
        Email email,
        Password password,
        Phone phone, 
        Dni dni,
        Status status
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
            Status = status
        };

        driver.AddDomainEvent(new DriverCreatedEvent(driver));

        return driver;
    }

    public void Update(Guid vehicleId, Guid providerId, DriverName driverName, Email email, Password password, Dni dni, Phone phone, Status status)
    {
        VehicleId = vehicleId;
        ProviderId = providerId;
        DriverName = driverName;
        Email = email;
        Password = password;
        Phone = phone;
        Dni = dni;
        Status = status;

        AddDomainEvent(new DriverUpdatedEvent(this));
    }
}

public enum Status
{
    Available,
    Unavailable
}
