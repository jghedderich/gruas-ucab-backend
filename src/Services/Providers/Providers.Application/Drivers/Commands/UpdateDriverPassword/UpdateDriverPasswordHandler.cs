using BuildingBlocks.Hashing;

namespace Providers.Application.Drivers.Commands.UpdateDriverPassword;

public class UpdateDriverPasswordHandlerI(IApplicationDbContext dbContext, IPasswordHasher passwordHasher)
    : ICommandHandler<UpdateDriverStatusCommand, UpdateDriverPasswordResult>
{
    public async Task<UpdateDriverPasswordResult> Handle(UpdateDriverStatusCommand command, CancellationToken cancellationToken)
    {
        var driverId = command.Driver.Id;
        var driver = await dbContext.Drivers
            .FindAsync([driverId], cancellationToken: cancellationToken);

        if (driver == null)
        {
            throw new DriverNotFoundException(command.Driver.Id);
        }

        UpdateDriverPassword(driver, command.Driver);

        dbContext.Drivers.Update(driver);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateDriverPasswordResult(true);
    }

    public void UpdateDriverPassword(Driver driver, UpdatePasswordDto dto)
    {
        driver.UpdatePassword(Password.Of(passwordHasher.Hash(dto.NewPassword)));
    }
}
