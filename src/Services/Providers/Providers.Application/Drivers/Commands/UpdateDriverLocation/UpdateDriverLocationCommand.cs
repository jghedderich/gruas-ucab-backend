
namespace Providers.Application.Drivers.Commands.UpdateDriverLocation;

public record UpdateDriverLocationCommand(UpdateLocationDto Location)
    : ICommand<UpdateDriverLocationResult>;

public record UpdateDriverLocationResult(Guid Id, bool IsSuccess);
public class UpdateDriverLocationCommandValidator : AbstractValidator<UpdateDriverLocationCommand>
{
    public UpdateDriverLocationCommandValidator()
    {
        RuleFor(x => x.Location.DriverId).NotEmpty().WithMessage("DriverId is required");
        RuleFor(x => x.Location.Address1).NotEmpty().WithMessage("Address1 is required");
        RuleFor(x => x.Location.Zip).NotEmpty().WithMessage("Zip is required");
        RuleFor(x => x.Location.City).NotEmpty().WithMessage("City is required");
        RuleFor(x => x.Location.Coordinates).NotEmpty().WithMessage("Coordinates are required");
    }
}
