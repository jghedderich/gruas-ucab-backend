using Orders.Application.Exceptions;
using Orders.Application.Extensions;

namespace Orders.Application.Policies.Queries.GetPolicyById;

public class GetPolicyByIdHandler(IApplicationDbContext dbContext) : IQueryHandler<GetPolicyByIdQuery, GetPolicyByIdResult>
{
    public async Task<GetPolicyByIdResult> Handle(GetPolicyByIdQuery query, CancellationToken cancellationToken)
    {
        Policy policy = await dbContext.Policies
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id.Equals(query.Id), cancellationToken)
                ?? throw new PolicyNotFoundException(query.Id);

        var policyDto = policy.ToPolicyDto();
        return new GetPolicyByIdResult(policyDto);
    }
}