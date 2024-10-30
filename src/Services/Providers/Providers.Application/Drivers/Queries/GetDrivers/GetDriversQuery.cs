using BuildingBlocks.Pagination;

namespace Providers.Application.Drivers.Queries.GetDrivers;

public record GetDriversQuery(PaginationRequest PaginationRequest) : IQuery<GetDriversResult>;

public record GetDriversResult(PaginatedResult<DriverDto> Drivers);
