namespace Orders.Application.CostDetails.Commands.UpdateCostDetail;

public record UpdateCostDetailCommand(CostDetailDto CostDetail) : ICommand<UpdateCostDetailResult>;

public record UpdateCostDetailResult(bool IsSuccess);

public class UpdateCostDetailCommandValidator : AbstractValidator<UpdateCostDetailCommand>
{
    public UpdateCostDetailCommandValidator()
    {
        RuleFor(x => x.CostDetail.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(o => o.CostDetail.Description).NotEmpty().WithMessage("Description is required");
        RuleFor(o => o.CostDetail.Amount).NotEmpty().WithMessage("Amount is required");
    }
}