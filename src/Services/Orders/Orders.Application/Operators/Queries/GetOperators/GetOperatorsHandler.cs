using BuildingBlocks.Pagination;
using Orders.Application.Extensions;

namespace Orders.Application.Operators.Queries.GetOperators;

public class GetOperatorsHandler(IApplicationDbContext dbContext) : IQueryHandler<GetOperatorsQuery, GetOperatorsResult>
{
    public async Task<GetOperatorsResult> Handle(GetOperatorsQuery query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.Operators.LongCountAsync(cancellationToken);

        var operators = await dbContext.Operators
            .Include(o => o.Orders)
            .OrderBy(o => o.OperatorName.FirstName)
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new GetOperatorsResult(
                new PaginatedResult<OperatorDto>(pageIndex,pageSize,totalCount,operators.ToOperatorDtoList())
            );
    }
}
