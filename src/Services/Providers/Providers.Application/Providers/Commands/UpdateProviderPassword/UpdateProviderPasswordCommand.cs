
namespace Providers.Application.Providers.Commands.UpdateProviderPassword;

public record UpdateProviderPasswordCommand(UpdatePasswordDto Provider)
    : ICommand<UpdateProviderPasswordResult>;

public record UpdateProviderPasswordResult(bool IsSuccess);

public class UpdateProviderPasswordCommandValidator : AbstractValidator<UpdateProviderPasswordCommand>
{
    public UpdateProviderPasswordCommandValidator()
    {
        RuleFor(x => x.Provider.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(x => x.Provider.NewPassword).NotEmpty().WithMessage("New Password is required");
    }
}
