
namespace Providers.Application.Drivers.Commands.UpdateDriverPassword;

public record UpdateDriverPasswordCommand(UpdatePasswordDto Driver)
    : ICommand<UpdateDriverPasswordResult>;

public record UpdateDriverPasswordResult(bool IsSuccess);

public class UpdateDriverPasswordCommandValidator : AbstractValidator<UpdateDriverPasswordCommand>
{
    public UpdateDriverPasswordCommandValidator()
    {
        RuleFor(x => x.Driver.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(x => x.Driver.NewPassword).NotEmpty().WithMessage("New Password is required");
    }
}
