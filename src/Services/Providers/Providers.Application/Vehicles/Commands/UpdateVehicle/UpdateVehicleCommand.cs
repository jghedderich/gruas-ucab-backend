
namespace Providers.Application.Vehicles.Commands.UpdateVehicle;

public record UpdateVehicleCommand(VehicleDto Vehicle) : ICommand<UpdateVehicleResult>;

public record UpdateVehicleResult(bool IsSuccess);

public class UpdateVehicleCommandValidator : AbstractValidator<UpdateVehicleCommand>
{
    public UpdateVehicleCommandValidator()
    {
        RuleFor(x => x.Vehicle.Type).NotEmpty().WithMessage("Type is required");
        RuleFor(x => x.Vehicle.Brand).NotEmpty().WithMessage("Brand is required");
        RuleFor(x => x.Vehicle.Model).NotEmpty().WithMessage("Model is required");
        RuleFor(x => x.Vehicle.Year).NotEmpty().WithMessage("Year is required");
    }
}
