using BuildingBlocks.Pagination;
using Orders.Application.Extensions;
using Orders.Application.Orders.Queries.GetOrders;

namespace Orders.Application.Orders.Queries.GetOrders;

public class GetOrdersHandler(IApplicationDbContext dbContext) : IQueryHandler<GetOrdersQuery, GetOrdersResult>
{
    public async Task<GetOrdersResult> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.Orders.LongCountAsync(cancellationToken);

        var orders = await dbContext.Orders
            .Include(o => o.CostDetails)
            .OrderBy(o => o.Client.Name.FirstName)
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new GetOrdersResult(
                new PaginatedResult<OrderDto>(pageIndex, pageSize, totalCount, orders.ToOrderDtoList())
            );
    }
}
