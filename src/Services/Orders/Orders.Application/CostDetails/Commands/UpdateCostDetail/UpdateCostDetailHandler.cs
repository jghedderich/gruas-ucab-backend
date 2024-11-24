using Orders.Application.Exceptions;

namespace Orders.Application.CostDetails.Commands.UpdateCostDetail;

public class UpdateCostDetailHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateCostDetailCommand, UpdateCostDetailResult>
{
    public async Task<UpdateCostDetailResult> Handle(UpdateCostDetailCommand command, CancellationToken cancellationToken)
    {
        var costDetailId = command.CostDetail.Id;
        var costDetail = await dbContext.CostDetails
            .FindAsync([costDetailId], cancellationToken: cancellationToken) ?? throw new CostDetailNotFoundException(command.CostDetail.Id);

        UpdateCostDetailWithNewValues(costDetail, command.CostDetail);

        dbContext.CostDetails.Update(costDetail);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateCostDetailResult(true);
    }

    public static void UpdateCostDetailWithNewValues(CostDetail costDetail, CostDetailDto costDetailDto)
    {
        var updatedDescription = costDetailDto.Description;
        var updatedAmount = costDetailDto.Amount;


        costDetail.Update(
            updatedDescription,
            updatedAmount
            );
    }
}