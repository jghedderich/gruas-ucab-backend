namespace Providers.Application.Drivers.Commands.UpdateDriverStatus;

public class UpdateDriverStatusHandlerI(IApplicationDbContext dbContext)
    : ICommandHandler<UpdateDriverStatusCommand, UpdateDriverStatusResult>
{
    public async Task<UpdateDriverStatusResult> Handle(UpdateDriverStatusCommand command, CancellationToken cancellationToken)
    {
        var driverId = command.Driver.Id;
        var driver = await dbContext.Drivers
            .FindAsync([driverId], cancellationToken: cancellationToken)
            ?? throw new DriverNotFoundException(command.Driver.Id);


        // If location is null, it means the driver just wants to update his status
        if (command.Driver.Location == null)
        {
            UpdateDriverStatus(driver, command.Driver);
        }
        else
        {
            // His status is geting updated because of an order
            UpdateDriverStatusBecauseOrderProgress(driver, command.Driver);
        }

        dbContext.Drivers.Update(driver);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateDriverStatusResult(true);
    }

    public static void UpdateDriverStatus(Driver driver, UpdateStatusDto dto)
    {
        if (driver.Status == Status.Available)
        {
            driver.UpdateStatus(Status.Unavailable);
        } else {
            driver.UpdateStatus(Status.Available);
        }
    }

    public static void UpdateDriverStatusBecauseOrderProgress(Driver driver, UpdateStatusDto dto) {
        
        if (dto.Status == "Cancelled" || dto.Status == "Completed")
        {
            driver.UpdateStatus(Status.Available);
        }
        else
        {
            driver.UpdateStatus(Status.Unavailable);
        }

        Location location = Location.Of(
            dto.Location!.Address1,
            dto.Location.Address2,
            Coordinates.Of(dto.Location.Coordinates.Latitude, dto.Location.Coordinates.Longitude),
            dto.Location.City,
            dto.Location.State,
            dto.Location.Zip);

        driver.UpdateLocation(location);

    }
}
