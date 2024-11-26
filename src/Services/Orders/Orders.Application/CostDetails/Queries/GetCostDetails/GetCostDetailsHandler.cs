using BuildingBlocks.Pagination;
using Orders.Application.Extensions;

namespace Orders.Application.CostDetails.Queries.GetCostDetails;

public class GetCostDetailsHandler(IApplicationDbContext dbContext) : IQueryHandler<GetCostDetailsQuery, GetCostDetailsResult>
{
    public async Task<GetCostDetailsResult> Handle(GetCostDetailsQuery query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.CostDetails.LongCountAsync(cancellationToken);

        var costDetails = await dbContext.CostDetails
            .OrderBy(o => o.OrderId)
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new GetCostDetailsResult(
                new PaginatedResult<CostDetailDto>(pageIndex, pageSize, totalCount, costDetails.ToCostDetailDtoList())
            );
    }
}
