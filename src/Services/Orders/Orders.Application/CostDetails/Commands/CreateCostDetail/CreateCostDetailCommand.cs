
namespace Orders.Application.CostDetails.Commands.CreateCostDetail;

public record CreateCostDetailCommand(CostDetailDto CostDetail) : ICommand<CreateCostDetailResult>;

public record CreateCostDetailResult(Guid Id);

public class CreateCostDetailCommandValidator : AbstractValidator<CreateCostDetailCommand>
{
    public CreateCostDetailCommandValidator()
    {
        RuleFor(o => o.CostDetail.OrderId).NotEmpty().WithMessage("OrderId is required");
        RuleFor(o => o.CostDetail.Description).NotEmpty().WithMessage("Description is required");
        RuleFor(o => o.CostDetail.Amount).NotEmpty().WithMessage("Amount is required");
        RuleFor(o => o.CostDetail.IsApproved).NotEmpty().WithMessage("IsApproved is required");
    }
}

