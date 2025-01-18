
using System.Diagnostics.CodeAnalysis;

namespace Providers.Application.Vehicles.Commands.UpdateVehicle;

[ExcludeFromCodeCoverage]
public class UpdateVehicleHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateVehicleCommand, UpdateVehicleResult>
{
    public async Task<UpdateVehicleResult> Handle(UpdateVehicleCommand command, CancellationToken cancellationToken)
    {
        var vehicleId = command.Vehicle.Id;
        var vehicle = await dbContext.Vehicles
            .FindAsync([vehicleId], cancellationToken: cancellationToken);

        if (vehicle == null)
        {
            throw new VehicleNotFoundException(command.Vehicle.Id);
        }

        UpdateVehicleWithNewValues(vehicle, command.Vehicle);

        dbContext.Vehicles.Update(vehicle);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateVehicleResult(true);
    }

    public void UpdateVehicleWithNewValues(Vehicle vehicle, VehicleDto vehicleDto)
    {
        var updatedType = (VehicleType)Enum.Parse(typeof(VehicleType), vehicleDto.Type);
        var updatedBrand = Brand.Of(vehicleDto.Brand);
        var updatedModel = Model.Of(vehicleDto.Model);
        var updatedYear = vehicleDto.Year;

        vehicle.Update(updatedType, updatedBrand, updatedModel, updatedYear, vehicle.LicensePlate, vehicle.Color);
    }
}
