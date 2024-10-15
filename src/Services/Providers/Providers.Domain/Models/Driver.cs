namespace Providers.Domain.Models;

public class Driver : Aggregate<DriverId>
{
    public DriverName DriverName { get; private set; } = default!;
    public Phone Phone { get; private set; } = default!;
    public Dni Dni { get; private set; } = default!;
    public static Driver Create(
        DriverId id, 
        DriverName driverName, 
        Phone phone, 
        Dni dni
        )
    {
        var driver = new Driver
        {
            Id = id,
            DriverName = driverName,
            Phone = phone,
            Dni = dni,
        };

        driver.AddDomainEvent(new DriverCreatedEvent(driver));

        return driver;
    }

    public void UpdateName(DriverName driverName, Dni dni, Phone phone)
    {
        DriverName = driverName;
        Phone = phone;
        Dni = dni;

        AddDomainEvent(new DriverUpdatedEvent(this));
    }

    public void 
    
}
