using System.Diagnostics.CodeAnalysis;
using BuildingBlocks.Pagination;
using Providers.Application.Extensions;

namespace Providers.Application.Drivers.Queries.GetDrivers;

[ExcludeFromCodeCoverage]
public class GetDriversHandler(IApplicationDbContext dbContext) : IQueryHandler<GetDriversQuery, GetDriversResult>
{
    public async Task<GetDriversResult> Handle(GetDriversQuery query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.Drivers.LongCountAsync(cancellationToken);

        var drivers = await dbContext.Drivers
            .OrderBy(d => d.DriverName.FirstName)
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        var driversDto = drivers.Select(driver => driver.ToDriverDto());

        return new GetDriversResult(
                new PaginatedResult<DriverDto>(pageIndex,pageSize, totalCount, driversDto) // driver.ToDriverDtoList()
            );
    }
}