using Admin.Application.Dtos;
using BuildingBlocks.CQRS;
using System.Threading.Tasks;
using System.Threading;

namespace Admin.Application.Departments.Commands.CreateDepartment;

public class CreateDepartmentHandler(IApplicationDbContext dbContext)
    : ICommandHandler<CreateDepartmentCommand, CreateDepartmentResult>
{
    public async Task<CreateDepartmentResult> Handle(CreateDepartmentCommand command, CancellationToken cancellationToken)
    {
        var department = CreateNewDepartment(command.Department);

        dbContext.Departments.Add(department);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateDepartmentResult(department.Id);
    }

    private static Department CreateNewDepartment(DepartmentDto departmentDto)
    {
        var newDepartment = Department.Create(
            id: Guid.NewGuid(),
            name: DepartmentName.Create(departmentDto.DepartmentName),
            description: departmentDto.Description  
        );

        return newDepartment;
    }
}
