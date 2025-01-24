using System.Diagnostics.CodeAnalysis;
using Providers.Application.Extensions;

namespace Providers.Application.Drivers.Queries.GetDriverById;

[ExcludeFromCodeCoverage]
public class GetDriverByIdHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetDriverByIdQuery, GetDriverByIdResult>
{
    public async Task<GetDriverByIdResult> Handle(GetDriverByIdQuery query, CancellationToken cancellationToken)
    {
        Driver driver = await dbContext.Drivers
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id.Equals(query.Id), cancellationToken)
                ?? throw new DriverNotFoundException(query.Id);

        var driverDto = driver.ToDriverDto();
        return new GetDriverByIdResult(driverDto);
    }
}
