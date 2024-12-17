using BuildingBlocks.Pagination;

namespace Admin.Application.Administrators.Queries.GetAdministrators;

public record GetAdministratorsQuery(PaginationRequest PaginationRequest)
    : IQuery<GetAdministratorsResult>;

public record GetAdministratorsResult(PaginatedResult<AdministratorDto> Administrators);


