namespace Providers.Domain.Models;

public class Driver : Entity<DriverId>
{
    internal Driver(ProviderId providerId, DriverId driverId, VehicleId vehicleId, DriverName driverName)
    {
        Id = DriverId.Of(Guid.NewGuid());
        ProviderId = providerId;
        VehicleId = vehicleId;
        DriverName = driverName;
    }

    public ProviderId ProviderId { get; private set; } = default!;
    public VehicleId VehicleId { get; private set; } = default!;
    public DriverName DriverName { get; private set; } = default!;
    public Company Company { get; private set; } = default!;
    
    // to be determined
}
