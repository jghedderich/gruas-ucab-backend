using BuildingBlocks.Pagination;

namespace Providers.Application.Vehicles.Queries.GetVehicles;

public record GetVehiclesQuery(PaginationRequest PaginationRequest) : IQuery<GetVehiclesResult>;

public record GetVehiclesResult(PaginatedResult<VehicleDto> Vehicles);
