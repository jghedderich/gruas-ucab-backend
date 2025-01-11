
namespace Providers.Application.Drivers.Commands.AssignDriver;

public record AssignDriverCommand(AssignDriverDto Driver)
: ICommand<AssignDriverResult>;

public record AssignDriverResult(bool IsSuccess);

public class AssignDriverCommandValidator : AbstractValidator<AssignDriverCommand>
{
    public AssignDriverCommandValidator()
    {
        RuleFor(x => x.Driver.OrderId).NotEmpty().WithMessage("OrderId is required");
        RuleFor(x => x.Driver.DriverId).NotEmpty().WithMessage("DriverId is required");
    }
}
