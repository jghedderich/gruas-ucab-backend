
namespace Providers.Application.Drivers.Commands.UpdateDriverStatus;

public record UpdateDriverStatusCommand(UpdateStatusDto Driver)
    : ICommand<UpdateDriverStatusResult>;

public record UpdateDriverStatusResult(bool IsSuccess);

public class UpdateDriverStatusCommandValidator : AbstractValidator<UpdateDriverStatusCommand>
{
    public UpdateDriverStatusCommandValidator()
    {
        RuleFor(x => x.Driver.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(x => x.Driver.Status).NotEmpty().WithMessage("Status is required");
    }
}
