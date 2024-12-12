
namespace Orders.Application.CostDetails.Commands.UpdateCostDetailStatus;

public record UpdateCostDetailStatusCommand(UpdateStatusCostDetailDto CostDetail)
    : ICommand<UpdateCostDetailStatusResult>;

public record UpdateCostDetailStatusResult(bool IsSuccess);

public class UpdateCostDetailStatusCommandValidator : AbstractValidator<UpdateCostDetailStatusCommand>
{
    public UpdateCostDetailStatusCommandValidator()
    {
        RuleFor(x => x.CostDetail.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(x => x.CostDetail.StatusC).NotEmpty().WithMessage("Status is required");
    }
}
