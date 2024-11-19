namespace Orders.Application.Operators.Commands.CreateOperator;

public record CreateOperatorCommand(OperatorDto Operator) : ICommand<CreateOperatorResult>;

public record CreateOperatorResult(Guid Id);

public class CreateOperatorCommandValidator : AbstractValidator<CreateOperatorCommand>
{
    public CreateOperatorCommandValidator()
    {
        RuleFor(p => p.Operator.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(p => p.Operator.Dni).NotEmpty().WithMessage("Dni is required");
        RuleFor(p => p.Operator.Phone).NotEmpty().WithMessage("Phone is required");
        RuleFor(p => p.Operator.Email).NotEmpty().WithMessage("Email is required");
    }
}
