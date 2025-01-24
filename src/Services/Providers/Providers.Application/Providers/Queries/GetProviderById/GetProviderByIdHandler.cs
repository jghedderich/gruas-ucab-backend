
using System.Diagnostics.CodeAnalysis;
using Providers.Application.Extensions;

namespace Providers.Application.Providers.Queries.GetProviderById;

[ExcludeFromCodeCoverage]
public class GetProviderByIdHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetProviderByIdQuery, GetProviderByIdResult>
{
    public async Task<GetProviderByIdResult> Handle(GetProviderByIdQuery query, CancellationToken cancellationToken)
    {
        Provider provider = await dbContext.Providers
                .Include(o => o.Vehicles)
                .Include(o => o.Drivers)
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id.Equals(query.Id), cancellationToken)
                ?? throw new ProviderNotFoundException(query.Id);

        var providerDto = provider.ToProviderDto();
        return new GetProviderByIdResult(providerDto);
    }
}
