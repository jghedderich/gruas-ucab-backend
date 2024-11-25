namespace Orders.Application.Policies.Commands.UpdatePolicy;

public record UpdatePolicyCommand(PolicyDto Policy) : ICommand<UpdatePolicyResult>;

public record UpdatePolicyResult(bool IsSuccess);

public class UpdatePolicyCommandValidator : AbstractValidator<UpdatePolicyCommand>
{
    public UpdatePolicyCommandValidator()
    {
        RuleFor(x => x.Policy.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(x => x.Policy.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Policy.AmountCovered).NotEmpty().WithMessage("Amount Covered is required");
        RuleFor(x => x.Policy.Price).NotEmpty().WithMessage("Price is required");
        RuleFor(x => x.Policy.Fees).NotEmpty().WithMessage("Fees is required");
    }
}