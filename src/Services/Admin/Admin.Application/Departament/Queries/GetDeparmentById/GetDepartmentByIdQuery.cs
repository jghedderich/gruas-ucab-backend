namespace Admin.Application.Departments.Queries.GetDepartmentById;

public record GetDepartmentByIdQuery(Guid Id)
    : IQuery<GetDepartmentByIdResult>;

public record GetDepartmentByIdResult(DepartmentDto Department);

