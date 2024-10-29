namespace Providers.Application.Drivers.Commands.UpdateDriver;

public class UpdateDriverHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateDriverCommand, UpdateDriverResult>
{
    public async Task<UpdateDriverResult> Handle(UpdateDriverCommand command, CancellationToken cancellationToken)
    {
        var driverId = command.Driver.Id;
        var driver = await dbContext.Drivers
            .FindAsync([driverId], cancellationToken: cancellationToken);

        if (driver == null)
        {
            throw new DriverNotFoundException(command.Driver.Id);
        }

        UpdateDriverWithNewValues(driver, command.Driver);

        dbContext.Drivers.Update(driver);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateDriverResult(true);
    }

    public void UpdateDriverWithNewValues(Driver driver, DriverDto driverDto)
    {
        var updatedName = driverDto.Name;
        var updatedEmail = driverDto.Email;
        var updateddniType = driverDto.Dni.ToDniType();
        var updatedNumber = driverDto.Dni.Number;
        var updatedPhone = driverDto.Phone;

        driver.Update(
            driverName: DriverName.Of(updatedName.FirstName, updatedName.LastName),Email.Of(updatedEmail),Dni.Of(updateddniType, updatedNumber), Phone.Of(updatedPhone));
    }
}
