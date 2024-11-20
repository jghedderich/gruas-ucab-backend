namespace Orders.Application.Operators.Commands.DeleteOperator;

public record DeleteOperatorCommand(Guid OperatorId) : ICommand<DeleteOperatorResult>;

public record DeleteOperatorResult(bool IsSuccess);

public class DeleteOperatorCommandValidator : AbstractValidator<DeleteOperatorCommand>
{
    public DeleteOperatorCommandValidator()
    {
        RuleFor(x => x.OperatorId).NotEmpty().WithMessage("OperatorId is required");
    }
}