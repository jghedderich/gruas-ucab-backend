
namespace Providers.Application.Drivers.Commands.UpdateDriverPassword;

public record UpdateDriverStatusCommand(UpdatePasswordDto Driver)
    : ICommand<UpdateDriverPasswordResult>;

public record UpdateDriverPasswordResult(bool IsSuccess);

public class UpdateDriverPasswordCommandValidator : AbstractValidator<UpdateDriverStatusCommand>
{
    public UpdateDriverPasswordCommandValidator()
    {
        RuleFor(x => x.Driver.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(x => x.Driver.Password).NotEmpty().WithMessage("Current Password is required");
        RuleFor(x => x.Driver.NewPassword).NotEmpty().WithMessage("New Password is required");
    }
}
