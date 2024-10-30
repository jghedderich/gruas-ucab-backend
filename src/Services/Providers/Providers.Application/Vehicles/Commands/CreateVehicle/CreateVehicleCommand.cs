namespace Providers.Application.Vehicles.Commands.CreateVehicle;

public record CreateVehicleCommand(VehicleDto Vehicle) : ICommand<CreateVehicleResult>;

public record CreateVehicleResult(Guid Id);

public class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
{
    public CreateVehicleCommandValidator()
    {
        RuleFor(v => v.Vehicle.Type).NotEmpty().WithMessage("Type is required");
        RuleFor(v => v.Vehicle.Brand).NotEmpty().WithMessage("Brand is required");
        RuleFor(v => v.Vehicle.Model).NotEmpty().WithMessage("Model is required");
        RuleFor(v => v.Vehicle.Year).NotEmpty().WithMessage("Year is required");
    }
}
