namespace Providers.Application.Vehicles.Queries.GetVehicleById;

public record GetVehicleByIdQuery(Guid Id) : IQuery<GetVehicleByIdResult>;

public record GetVehicleByIdResult(VehicleDto Vehicle);
