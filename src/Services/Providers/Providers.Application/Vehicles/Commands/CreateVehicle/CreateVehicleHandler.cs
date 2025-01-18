using System.Diagnostics.CodeAnalysis;

namespace Providers.Application.Vehicles.Commands.CreateVehicle;

[ExcludeFromCodeCoverage]
public class CreateVehicleHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateVehicleCommand, CreateVehicleResult>
{
    public async Task<CreateVehicleResult> Handle(CreateVehicleCommand command, CancellationToken cancellationToken)
    {
        var vehicle = CreateNewVehicle(command.Vehicle);

        dbContext.Vehicles.Add(vehicle);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateVehicleResult(vehicle.Id);
    }

    private static Vehicle CreateNewVehicle(VehicleDto vehicleDto)
    {
        var newVehicle = Vehicle.Create(
                id: Guid.NewGuid(),
                providerId: vehicleDto.ProviderId,
                type: (VehicleType)Enum.Parse(typeof(VehicleType), vehicleDto.Type),
                brand: Brand.Of(vehicleDto.Brand),
                model: Model.Of(vehicleDto.Model),
                year: vehicleDto.Year,
                licensePlate: vehicleDto.LicensePlate,
                color: vehicleDto.Color
            );

        return newVehicle;
    }
}

