
namespace Orders.Application.CostDetails.Commands.CreateCostDetail;

public class CreateCostDetailHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateCostDetailCommand, CreateCostDetailResult>
{
    public async Task<CreateCostDetailResult> Handle(CreateCostDetailCommand command, CancellationToken cancellationToken)
    {

        var costDetail = CreateNewCostDetail(command.CostDetail);

        dbContext.CostDetails.Add(costDetail);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateCostDetailResult(costDetail.Id);
    }

    private static CostDetail CreateNewCostDetail(CostDetailDto costDetailDto)
    {

        var newCostDetail = CostDetail.Create(
                id: Guid.NewGuid(),
                orderId: costDetailDto.OrderId,
                description: costDetailDto.Description,
                amount: costDetailDto.Amount,
                isApproved: costDetailDto.IsApproved
            );

        return newCostDetail;
    }


}