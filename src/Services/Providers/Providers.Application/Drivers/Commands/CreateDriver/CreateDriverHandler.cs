using BuildingBlocks.Hashing;

namespace Providers.Application.Drivers.Commands.CreateDriver;

public class CreateDriverHandler(IApplicationDbContext dbContext, IPasswordHasher passwordHasher) 
    : ICommandHandler<CreateDriverCommand, CreateDriverResult>
{
    public async Task<CreateDriverResult> Handle(CreateDriverCommand command, CancellationToken cancellationToken)
    {
        var driver = CreateNewDriver(command.Driver);

        dbContext.Drivers.Add(driver);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateDriverResult(driver.Id);
    }

    private Driver CreateNewDriver(DriverDto driverDto)
    {
        var dniType = driverDto.Dni.ToDniType();

        var dni = Dni.Of(dniType, driverDto.Dni.Number);

        Status status = Status.Available; // Default value
        if (!string.IsNullOrEmpty(driverDto.Status) && !Enum.TryParse(driverDto.Status, out status)) ;

            var newDriver = Driver.Create(
                id: Guid.NewGuid(),
                driverName: DriverName.Of(driverDto.Name.FirstName, driverDto.Name.LastName),
                providerId: driverDto.ProviderId,
                vehicleId: driverDto.VehicleId,
                email: Email.Of(driverDto.Email!),
                password: Password.Of(passwordHasher.Hash(driverDto.Password!)),
                phone: Phone.Of(driverDto.Phone!),
                dni: dni,
                status: status
        );

        return newDriver;

    }
}