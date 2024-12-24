namespace Admin.Application.Administrators.Commands.UpdateAdministratorPassword;

public record UpdateAdministratorPasswordCommand(UpdatePasswordDto Administrator)
    : ICommand<UpdateAdministratorPasswordResult>;

public record UpdateAdministratorPasswordResult(bool IsSuccess);

public class UpdateAdministratorPasswordCommandValidator : AbstractValidator<UpdateAdministratorPasswordCommand>
{
    public UpdateAdministratorPasswordCommandValidator()
    {
        RuleFor(x => x.Administrator.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(x => x.Administrator.NewPassword).NotEmpty().WithMessage("New Password is required");
    }
}
