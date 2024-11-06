using BuildingBlocks.Pagination;

namespace Orders.Application.Operators.Queries.GetOperators;

public record GetOperatorsQuery(PaginationRequest PaginationRequest)
    : IQuery<GetOperatorsResult>;

public record GetOperatorsResult(PaginatedResult<OperatorDto> Operators);
