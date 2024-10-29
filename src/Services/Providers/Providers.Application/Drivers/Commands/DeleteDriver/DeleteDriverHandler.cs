namespace Providers.Application.Drivers.Commands.DeleteDriver;

public class DeleteDriverHandler(IApplicationDbContext dbContext) : ICommandHandler<DeleteDriverCommand, DeleteDriverResult>
{
    public async Task<DeleteDriverResult> Handle(DeleteDriverCommand command, CancellationToken cancellationToken)
    {
        var driver = await dbContext.Drivers
            .FindAsync([command.DriverId], cancellationToken)
            ?? throw new DriverNotFoundException(command.DriverId);

        dbContext.Drivers.Remove(driver);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteDriverResult(true);
    }
}
