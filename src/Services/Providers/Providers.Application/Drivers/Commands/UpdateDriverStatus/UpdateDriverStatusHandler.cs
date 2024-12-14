namespace Providers.Application.Drivers.Commands.UpdateDriverStatus;

public class UpdateDriverStatusHandlerI(IApplicationDbContext dbContext)
    : ICommandHandler<UpdateDriverStatusCommand, UpdateDriverStatusResult>
{
    public async Task<UpdateDriverStatusResult> Handle(UpdateDriverStatusCommand command, CancellationToken cancellationToken)
    {
        var driverId = command.Driver.Id;
        var driver = await dbContext.Drivers
            .FindAsync([driverId], cancellationToken: cancellationToken);

        if (driver == null)
        {
            throw new DriverNotFoundException(command.Driver.Id);
        }

        UpdateDriverStatus(driver, command.Driver);

        dbContext.Drivers.Update(driver);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateDriverStatusResult(true);
    }

    public static void UpdateDriverStatus(Driver driver, UpdateStatusDto dto)
    {
        // might need to be refactored
        if (driver.Status == Status.Available)
        {
            driver.UpdateStatus(Status.Unavailable);
        } else {
            driver.UpdateStatus(Status.Available);
        }
    }
}
