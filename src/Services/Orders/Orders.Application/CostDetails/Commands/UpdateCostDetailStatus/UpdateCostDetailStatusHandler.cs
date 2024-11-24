using Orders.Application.Exceptions;
using Orders.Application.Orders.Commands.UpdateOrderStatus;

namespace Orders.Application.CostDetails.Commands.UpdateCostDetailStatus;

public class UpdateCostDetailStatusHandlerI(IApplicationDbContext dbContext)
    : ICommandHandler<UpdateCostDetailStatusCommand, UpdateCostDetailStatusResult>
{
    public async Task<UpdateCostDetailStatusResult> Handle(UpdateCostDetailStatusCommand command, CancellationToken cancellationToken)
    {
        var costDetailId = command.CostDetail.Id;
        var status = command.CostDetail.IsApproved;
        var costDetail = await dbContext.CostDetails
            .FindAsync([costDetailId], cancellationToken: cancellationToken) ?? throw new CostDetailNotFoundException(command.CostDetail.Id);


        UpdateCostDetailStatus(costDetail, status);

        dbContext.CostDetails.Update(costDetail);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateCostDetailStatusResult(true);
    }

    public static void UpdateCostDetailStatus(CostDetail costDetail, bool status)
    {
        costDetail.UpdateStatus(status);

    }
}
