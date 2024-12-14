using Admin.Application.Extensions;

namespace Admin.Application.Departments.Queries.GetDepartmentById;

public class GetDepartmentsHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetDepartmentByIdQuery, GetDepartmentByIdResult>
{
    public async Task<GetDepartmentByIdResult> Handle(GetDepartmentByIdQuery query, CancellationToken cancellationToken)
    {
        var department = await dbContext.Departments
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id.Equals(query.Id), cancellationToken)
            ?? throw new DepartmentNotFoundException(query.Id);

        var departmentDto = department.ToDepartmentDto();
        return new GetDepartmentByIdResult(departmentDto);
    }
}
