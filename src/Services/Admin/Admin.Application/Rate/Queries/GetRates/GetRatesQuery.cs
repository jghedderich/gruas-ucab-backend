using BuildingBlocks.Pagination;

namespace Admin.Application.Rates.Queries.GetRates;

public record GetRatesQuery(PaginationRequest PaginationRequest) : IQuery<GetRatesResult>;

public record GetRatesResult(PaginatedResult<RateDto> Rates);



