using Orders.Application.Exceptions;
using Orders.Application.Orders.Commands.UpdateOrderStatus;

namespace Orders.Application.CostDetails.Commands.UpdateCostDetailStatus;

public class UpdateCostDetailStatusHandlerI(IApplicationDbContext dbContext)
    : ICommandHandler<UpdateCostDetailStatusCommand, UpdateCostDetailStatusResult>
{
    public async Task<UpdateCostDetailStatusResult> Handle(UpdateCostDetailStatusCommand command, CancellationToken cancellationToken)
    {
        var costDetailId = command.CostDetail.Id;
        var statusC = command.CostDetail.StatusC;
        var costDetail = await dbContext.CostDetails
            .FindAsync([costDetailId], cancellationToken: cancellationToken) ?? throw new CostDetailNotFoundException(command.CostDetail.Id);


        UpdateCostDetailStatus(costDetail, statusC);

        dbContext.CostDetails.Update(costDetail);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateCostDetailStatusResult(true);
    }

    public static void UpdateCostDetailStatus(CostDetail costDetail, string statusC)
    {
        if (Enum.TryParse<StatusCO>(statusC, out StatusCO statusEnum))
        costDetail.UpdateStatus(CostDetailStatus.Of(statusEnum));

    }
}
