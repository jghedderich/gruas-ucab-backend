namespace Providers.Application.Drivers.Commands.UpdateDriverPassword;

public class UpdateDriverPasswordHandlerI(IApplicationDbContext dbContext)
    : ICommandHandler<UpdateDriverPasswordCommand, UpdateDriverPasswordResult>
{
    public async Task<UpdateDriverPasswordResult> Handle(UpdateDriverPasswordCommand command, CancellationToken cancellationToken)
    {
        var driverId = command.Driver.Id;
        var driver = await dbContext.Drivers
            .FindAsync([driverId], cancellationToken: cancellationToken);

        if (driver == null)
        {
            throw new DriverNotFoundException(command.Driver.Id);
        }

        if (driver.Password.Value != command.Driver.Password)
        {
            throw new WrongPasswordException(command.Driver.Id);
        }

        UpdateDriverPassword(driver, command.Driver);

        dbContext.Drivers.Update(driver);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateDriverPasswordResult(true);
    }

    public static void UpdateDriverPassword(Driver driver, UpdatePasswordDto dto)
    {
        driver.UpdatePassword(Password.Of(dto.NewPassword));
    }
}
