
namespace Providers.Application.Drivers.Commands.UpdateDriverLocation;

public class UpdateDriverLocationHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateDriverLocationCommand, UpdateDriverLocationResult>
{
    public async Task<UpdateDriverLocationResult> Handle(UpdateDriverLocationCommand command, CancellationToken cancellationToken)
    {
        var driverId = command.Location.DriverId;
        var driver = await dbContext.Drivers
            .FindAsync([driverId], cancellationToken: cancellationToken) ?? throw new DriverNotFoundException(command.Location.DriverId);
        UpdateDriverLocationWithNewValues(driver, command.Location);

        dbContext.Drivers.Update(driver);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateDriverLocationResult(driverId, true);
    }

    public static void UpdateDriverLocationWithNewValues(Driver driver, UpdateLocationDto locationDto)
    {
        var latitude = locationDto.Coordinates.Latitude;
        var longitude = locationDto.Coordinates.Longitude;

        driver.UpdateLocation(
            Location.Of(
                locationDto.Address1, 
                locationDto.Address2, 
                Coordinates.Of(latitude, longitude), 
                locationDto.City, 
                locationDto.State, 
                locationDto.Zip)
            );
    }
}
