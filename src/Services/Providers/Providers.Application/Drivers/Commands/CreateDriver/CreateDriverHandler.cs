namespace Providers.Application.Drivers.Commands.CreateDriver;

public class CreateDriverHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateDriverCommand, CreateDriverResult>
{
    public async Task<CreateDriverResult> Handle(CreateDriverCommand command, CancellationToken cancellationToken)
    {
        var driver = CreateNewDriver(command.Driver);

        dbContext.Drivers.Add(driver);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateDriverResult(driver.Id);
    }

    private static Driver CreateNewDriver(DriverDto driverDto)
    {
        var dniType = driverDto.Dni.ToDniType();

        var dni = Dni.Of(dniType, driverDto.Dni.Number);

        var newDriver = Driver.Create(
                id: Guid.NewGuid(),
                driverName: DriverName.Of(driverDto.Name.FirstName, driverDto.Name.LastName),
                providerId: driverDto.ProviderId,
                vehicleId: driverDto.VehicleId,
                email: Email.Of(driverDto.Email),
                password: Password.Of(driverDto.Password),
                phone: Phone.Of(driverDto.Phone),
                dni: dni,
                status: Status.Of(driverDto.Status.ToStatusType())
                
        );

        return newDriver;

    }
}