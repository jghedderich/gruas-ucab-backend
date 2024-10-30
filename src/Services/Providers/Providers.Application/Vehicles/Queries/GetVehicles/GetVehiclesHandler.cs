using BuildingBlocks.Pagination;
using Providers.Application.Extensions;

namespace Providers.Application.Vehicles.Queries.GetVehicles;

public class GetVehicleHandler(IApplicationDbContext dbContext) : IQueryHandler<GetVehiclesQuery, GetVehiclesResult>
{
    public async Task<GetVehiclesResult> Handle(GetVehiclesQuery query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.Vehicles.LongCountAsync(cancellationToken);

        var vehicles = await dbContext.Vehicles
            .OrderBy(v => v.Type)
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        var vehiclesDto = vehicles.Select(vehicle => vehicle.ToVehicleDto());

        return new GetVehiclesResult(
                new PaginatedResult<VehicleDto>(pageIndex,pageSize,totalCount,vehiclesDto)
            );
    }
}

