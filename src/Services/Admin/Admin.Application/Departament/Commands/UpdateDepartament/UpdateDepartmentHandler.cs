using System.Diagnostics.CodeAnalysis;

namespace Admin.Application.Departament.Commands.UpdateDepartament;

[ExcludeFromCodeCoverage]
public class UpdateDepartmentHandler(IApplicationDbContext dbContext)
    : ICommandHandler<UpdateDepartmentCommand, UpdateDepartmentResult>
{
    public async Task<UpdateDepartmentResult> Handle(UpdateDepartmentCommand command, CancellationToken cancellationToken)
    {
        var departmentId = command.Department.Id;
        var department = await dbContext.Departments
            .FindAsync(new object[] { departmentId }, cancellationToken: cancellationToken);

        if (department == null)
        {
            throw new DepartmentNotFoundException(command.Department.Id);
        }

        UpdateDepartmentWithNewValues(department, command.Department);

        dbContext.Departments.Update(department);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateDepartmentResult(true);
    }

    public void UpdateDepartmentWithNewValues(Department department, DepartmentDto departmentDto)
    {
        department.Update(
            name: DepartmentName.Create(departmentDto.DepartmentName),
            description: departmentDto.Description);
    }
}
