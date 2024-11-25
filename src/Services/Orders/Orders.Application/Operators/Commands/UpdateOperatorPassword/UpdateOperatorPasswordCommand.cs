namespace Orders.Application.Operators.Commands.UpdateOperatorPassword;

public record UpdateOperatorPasswordCommand(UpdatePasswordDto Operator)
    : ICommand<UpdateOperatorPasswordResult>;

public record UpdateOperatorPasswordResult(bool IsSuccess);

public class UpdateOperatorPasswordCommandValidator : AbstractValidator<UpdateOperatorPasswordCommand>
{
    public UpdateOperatorPasswordCommandValidator()
    {
        RuleFor(x => x.Operator.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(x => x.Operator.Password).NotEmpty().WithMessage("Current Password is required");
        RuleFor(x => x.Operator.NewPassword).NotEmpty().WithMessage("New Password is required");
    }
}
