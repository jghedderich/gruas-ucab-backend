namespace Orders.Application.Policies.Commands.DeletePolicy;

public record DeletePolicyCommand(Guid PolicyId) : ICommand<DeletePolicyResult>;

public record DeletePolicyResult(bool IsSuccess);

public class DeletePolicyCommandValidator : AbstractValidator<DeletePolicyCommand>
{
    public DeletePolicyCommandValidator()
    {
        RuleFor(x => x.PolicyId).NotEmpty().WithMessage("PolicyId is required");
    }
}

