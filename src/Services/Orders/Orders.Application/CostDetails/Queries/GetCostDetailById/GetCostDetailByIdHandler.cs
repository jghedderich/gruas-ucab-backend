using Orders.Application.Exceptions;
using Orders.Application.Extensions;

namespace Orders.Application.CostDetails.Queries.GetCostDetailById;

public class GetCostDetailByIdHandler(IApplicationDbContext dbContext) : IQueryHandler<GetCostDetailByIdQuery, GetCostDetailByIdResult>
{
    public async Task<GetCostDetailByIdResult> Handle(GetCostDetailByIdQuery query, CancellationToken cancellationToken)
    {
        CostDetail costDetail = await dbContext.CostDetails
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id.Equals(query.Id), cancellationToken)
                ?? throw new CostDetailNotFoundException(query.Id);

        var costDetailDto = costDetail.ToCostDetailDto();
        return new GetCostDetailByIdResult(costDetailDto);
    }
}