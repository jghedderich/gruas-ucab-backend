using Orders.Application.Exceptions;
using Orders.Application.Extensions;

namespace Orders.Application.Operators.Queries.GetOperatorById;

public class GetOperatorByIdHandler(IApplicationDbContext dbContext) : IQueryHandler<GetOperatorByIdQuery, GetOperatorByIdResult>
{
    public async Task<GetOperatorByIdResult> Handle(GetOperatorByIdQuery query, CancellationToken cancellationToken)
    {
        Operator operator1 = await dbContext.Operators
                .Include(o => o.Orders)
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id.Equals(query.Id), cancellationToken)
                ?? throw new OperatorNotFoundException(query.Id);

        var operatorDto = operator1.ToOperatorDto();
        return new GetOperatorByIdResult(operatorDto);
    }
}