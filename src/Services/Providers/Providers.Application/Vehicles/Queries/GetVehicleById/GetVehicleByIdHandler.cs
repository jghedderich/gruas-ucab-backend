using Providers.Application.Extensions;

namespace Providers.Application.Vehicles.Queries.GetVehicleById;

public class GetVehicleByIdHandler(IApplicationDbContext dbContext) : IQueryHandler<GetVehicleByIdQuery, GetVehicleByIdResult>
{
    public async Task<GetVehicleByIdResult> Handle(GetVehicleByIdQuery query, CancellationToken cancellationToken)
    {
        Vehicle vehicle = await dbContext.Vehicles
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Id.Equals(query.Id), cancellationToken)
            ?? throw new VehicleNotFoundException(query.Id);

        var vehicleDto = vehicle.ToVehicleDto();
        return new GetVehicleByIdResult(vehicleDto);
    }
}
