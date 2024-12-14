using BuildingBlocks.Pagination;

namespace Orders.Application.Policies.Queries.GetPolicies;

public record GetPoliciesQuery(PaginationRequest PaginationRequest)
    : IQuery<GetPoliciesResult>;

public record GetPoliciesResult(PaginatedResult<PolicyDto> Policies);