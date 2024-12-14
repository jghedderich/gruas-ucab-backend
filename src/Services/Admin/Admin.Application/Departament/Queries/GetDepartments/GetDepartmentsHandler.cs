using BuildingBlocks.Pagination;
using Admin.Application.Extensions;

namespace Admin.Application.Departments.Queries.GetDepartments;

public class GetDepartmentsHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetDepartmentsQuery, GetDepartmentsResult>
{
    public async Task<GetDepartmentsResult> Handle(GetDepartmentsQuery query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.Departments.LongCountAsync(cancellationToken);

        var departments = await dbContext.Departments
            .OrderBy(d => d.Name.Value) 
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new GetDepartmentsResult(
            new PaginatedResult<DepartmentDto>(pageIndex, pageSize, totalCount, departments.ToDepartmentDtoList())
        );
    }
}
