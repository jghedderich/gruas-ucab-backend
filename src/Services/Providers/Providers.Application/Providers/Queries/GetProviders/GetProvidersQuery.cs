using BuildingBlocks.Pagination;

namespace Providers.Application.Providers.Queries.GetProviders;

public record GetProvidersQuery(PaginationRequest PaginationRequest)
    : IQuery<GetProvidersResult>;

public record GetProvidersResult(PaginatedResult<ProviderDto> Providers);
