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

    public static void UpdateDriverWithNewValues(Driver driver, DriverDto driverDto)
    {
        var updatedName = driverDto.Name;
        var updatedEmail = driverDto.Email;
        var updatedDniType = driverDto.Dni.ToDniType();
        var updatedNumber = driverDto.Dni.Number;
        var updatedPhone = driverDto.Phone;

        driver.Update(
            vehicleId: driverDto.VehicleId,
            providerId: driverDto.ProviderId,
            driverName: DriverName.Of(updatedName.FirstName, updatedName.LastName),
            email: Email.Of(updatedEmail),
            dni: Dni.Of(updatedDniType, updatedNumber),
            phone: Phone.Of(updatedPhone),
            status: (Status)Enum.Parse(typeof(Status), driverDto.Status)
            );
    }
}
