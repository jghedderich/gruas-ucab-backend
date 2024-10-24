using BuildingBlocks.Pagination;
using Providers.Application.Extensions;

namespace Providers.Application.Providers.Queries.GetProviders;

public class GetProvidersHandler(IApplicationDbContext dbContext) : IQueryHandler<GetProvidersQuery, GetProvidersResult>
{
  public async Task<GetProvidersResult> Handle(GetProvidersQuery query, CancellationToken cancellationToken){
    var pageIndex = query.PaginationRequest.PageIndex;
    var pageSize = query.PaginationRequest.PageSize;

    var totalCount = await dbContext.Providers.LongCountAsync(cancellationToken);

    var providers = await dbContext.Providers
          .Include(p => p.Drivers)
          .OrderBy(p => p.ProviderName.FirstName)
          .Skip(pageIndex * pageSize)
          .Take(pageSize)
          .ToListAsync(cancellationToken);

    return new GetProvidersResult(
          new PaginatedResult<ProviderDto>(pageIndex, pageSize, totalCount, providers.ToProviderDtoList())
    );
  }
}

