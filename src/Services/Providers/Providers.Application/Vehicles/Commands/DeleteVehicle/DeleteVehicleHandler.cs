using System.Diagnostics.CodeAnalysis;

namespace Providers.Application.Vehicles.Commands.DeleteVehicle;

[ExcludeFromCodeCoverage]
public class DeleteVehicleHandler(IApplicationDbContext dbContext) : ICommandHandler<DeleteVehicleCommand, DeleteVehicleResult>
{
    public async Task<DeleteVehicleResult> Handle(DeleteVehicleCommand command, CancellationToken cancellationToken)
    {
        var vehicle = await dbContext.Vehicles
            .FindAsync([command.VehicleId], cancellationToken)
            ?? throw new VehicleNotFoundException(command.VehicleId);

        dbContext.Vehicles.Remove(vehicle);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteVehicleResult(true);
    }
}
