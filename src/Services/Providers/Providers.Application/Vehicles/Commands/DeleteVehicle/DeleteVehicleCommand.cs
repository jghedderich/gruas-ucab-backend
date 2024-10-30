namespace Providers.Application.Vehicles.Commands.DeleteVehicle;

public record DeleteVehicleCommand(Guid VehicleId) : ICommand<DeleteVehicleResult>;

public record DeleteVehicleResult(bool IsSuccess);

public class DeleteVehicleCommandValidator : AbstractValidator<DeleteVehicleCommand>
{
    public DeleteVehicleCommandValidator()
    {
        RuleFor(x => x.VehicleId).NotEmpty().WithMessage("VehicleId is required");
    }
}
