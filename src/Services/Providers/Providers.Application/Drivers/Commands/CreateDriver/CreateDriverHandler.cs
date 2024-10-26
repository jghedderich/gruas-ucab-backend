using Providers.Application.Drivers.Commands.CreateDriver;

namespace Providers.Application.Providers.Commands.CreateDriver;

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
        var dni = Dni.Of(driverDto.Dni.Type, driverDto.Dni.Number);

        var newDriver = Driver.Create(
                id: Guid.NewGuid(),
                driverName: DriverName.Of(driverDto.Name.FirstName, driverDto.Name.LastName),
                providerId: driverDto.ProviderId,
                vehicleId: driverDto.VehicleId, 
                email: Email.Of(driverDto.Email),
                phone: Phone.Of(driverDto.Phone),
                dni: dni
        );

        return newDriver;

    }
}