using Admin.Application.Dtos;
using Admin.Domain.Models;

namespace Admin.Application.Extensions;

public static class DepartmentExtensions
{
    public static IEnumerable<DepartmentDto> ToDepartmentDtoList(this IEnumerable<Department> departments)
    {
        return departments.Select(d => new DepartmentDto(
            Id: d.Id,
            DepartmentName: d.Name.Value,
            Description: d.Description,
            IsActive: d.IsActive
        ));
    }

    public static DepartmentDto ToDepartmentDto(this Department department)
    {
        return DtoFromDepartment(department);
    }

    private static DepartmentDto DtoFromDepartment(Department department)
    {
        return new DepartmentDto(
            Id: department.Id,
            DepartmentName: department.Name.Value,
            Description: department.Description ,
            IsActive: department.IsActive
        );
    }
}
