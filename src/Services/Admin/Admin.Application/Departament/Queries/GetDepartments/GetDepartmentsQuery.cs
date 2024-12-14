using BuildingBlocks.Pagination;

namespace Admin.Application.Departments.Queries.GetDepartments;

public record GetDepartmentsQuery(PaginationRequest PaginationRequest)
    : IQuery<GetDepartmentsResult>;

public record GetDepartmentsResult(PaginatedResult<DepartmentDto> Departments);
