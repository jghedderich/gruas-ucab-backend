
namespace Providers.Application.Providers.Queries.GetProviderById;

public class GetProviderByIdHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetProviderByIdQuery, GetProviderByIdResult>
{
    public async Task<GetProviderByIdResult> Handle(GetProviderByIdQuery query, CancellationToken cancellationToken)
    {
        // get orders by name using dbContext
        // return result

        Provider provider = await dbContext.Providers
                .Include(o => o.Vehicles)
                .Include(o => o.Drivers)
                .AsNoTracking()
                .Where(o => o.Id.Equals(query.Id))
                .FirstOrDefaultAsync(cancellationToken: cancellationToken) 
                ?? throw new ProviderNotFoundException(query.Id);

        return new GetProviderByIdResult(provider);
    }
}
