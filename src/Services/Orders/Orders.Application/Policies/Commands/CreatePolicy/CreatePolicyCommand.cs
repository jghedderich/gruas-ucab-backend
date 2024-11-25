namespace Orders.Application.Policies.Commands.CreatePolicy;

public record CreatePolicyCommand(PolicyDto Policy) : ICommand<CreatePolicyResult>;

public record CreatePolicyResult(Guid Id);

public class CreatePolicyCommandValidator : AbstractValidator<CreatePolicyCommand>
{
    public CreatePolicyCommandValidator()
    {
        RuleFor(p => p.Policy.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(p => p.Policy.AmountCovered).NotEmpty().WithMessage("Amount Covered is required");
        RuleFor(p => p.Policy.Price).NotEmpty().WithMessage("Price is required");
        RuleFor(p => p.Policy.Fees).NotEmpty().WithMessage("Fees is required");
    }
}
