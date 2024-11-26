using BuildingBlocks.Pagination;

namespace Orders.Application.CostDetails.Queries.GetCostDetails;

public record GetCostDetailsQuery(PaginationRequest PaginationRequest)
    : IQuery<GetCostDetailsResult>;

public record GetCostDetailsResult(PaginatedResult<CostDetailDto> CostDetails);
