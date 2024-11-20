namespace Orders.Application.Operators.Commands.UpdateOperator;

public record UpdateOperatorCommand(OperatorDto Operator) : ICommand<UpdateOperatorResult>;

public record UpdateOperatorResult(bool IsSuccess);

public class UpdateOperatorCommandValidator : AbstractValidator<UpdateOperatorCommand>
{
    public UpdateOperatorCommandValidator()
    {
        RuleFor(x => x.Operator.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(x => x.Operator.Name.FirstName).NotEmpty().WithMessage("First name is required");
        RuleFor(x => x.Operator.Name.LastName).NotEmpty().WithMessage("Last name is required");
        RuleFor(x => x.Operator.Phone).NotEmpty().WithMessage("Phone is required");
        RuleFor(x => x.Operator.Email).NotEmpty().WithMessage("Email is required");
        RuleFor(x => x.Operator.Dni.Number).NotEmpty().WithMessage("Dni number is required");
    }
}