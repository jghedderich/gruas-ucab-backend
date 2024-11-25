using BuildingBlocks.Pagination;
using Orders.Application.Extensions;

namespace Orders.Application.Policies.Queries.GetPolicies;

public class GetPoliciesHandler(IApplicationDbContext dbContext) : IQueryHandler<GetPoliciesQuery, GetPoliciesResult>
{
    public async Task<GetPoliciesResult> Handle(GetPoliciesQuery query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.Policies.LongCountAsync(cancellationToken);

        var policies = await dbContext.Policies
            .OrderBy(o => o.Name)
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new GetPoliciesResult(
                new PaginatedResult<PolicyDto>(pageIndex, pageSize, totalCount, policies.ToPolicyDtoList())
            );
    }
}
