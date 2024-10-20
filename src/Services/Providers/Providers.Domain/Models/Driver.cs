namespace Providers.Domain.Models;

public class Driver : Aggregate<Guid>
{
    public Guid ProviderId { get; private set; } = default!;
    public Guid VehicleId { get; private set; } = default!;
    public DriverName DriverName { get; private set; } = default!;
    public Email Email { get; private set; } = default!;
    public Phone Phone { get; private set; } = default!;
    public Dni Dni { get; private set; } = default!;

    
    public static Driver Create(
        Guid id,
        DriverName driverName, 
        Guid providerId,
        Guid vehicleId,
        Email email,
        Phone phone, 
        Dni dni
     )
    {
        var driver = new Driver
        {
            Id = id,
            DriverName = driverName,
            ProviderId = providerId,
            VehicleId = vehicleId,
            Email = email,
            Phone = phone,
            Dni = dni,
        };

        driver.AddDomainEvent(new DriverCreatedEvent(driver));

        return driver;
    }

    public void Update(DriverName driverName, Email email, Dni dni, Phone phone)
    {
        DriverName = driverName;
        Email = email;
        Phone = phone;
        Dni = dni;

        AddDomainEvent(new DriverUpdatedEvent(this));
    }
}
