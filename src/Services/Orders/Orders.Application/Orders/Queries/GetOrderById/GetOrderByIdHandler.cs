using Orders.Application.Exceptions;
using Orders.Application.Extensions;

namespace Orders.Application.Orders.Queries.GetOrderById;

public class GetOrderByIdHandler(IApplicationDbContext dbContext) : IQueryHandler<GetOrderByIdQuery, GetOrderByIdResult>
{
    public async Task<GetOrderByIdResult> Handle(GetOrderByIdQuery query, CancellationToken cancellationToken)
    {
        Order order = await dbContext.Orders
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id.Equals(query.Id), cancellationToken)
                ?? throw new OrderNotFoundException(query.Id);

        var orderDto = order.ToOrderDto();
        return new GetOrderByIdResult(orderDto);
    }
}