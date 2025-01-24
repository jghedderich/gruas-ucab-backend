
using System.Diagnostics.CodeAnalysis;
using Admin.Application.Departments.Commands.DeleteDepartment;

namespace Admin.Application.Departament.Commands.DeleteDepartament;

[ExcludeFromCodeCoverage]
public class DeleteDepartmentHandler(IApplicationDbContext dbContext)
    : ICommandHandler<DeleteDepartmentCommand, DeleteDepartmentResult>
{
    public async Task<DeleteDepartmentResult> Handle(DeleteDepartmentCommand command, CancellationToken cancellationToken)
    {
        var department = await dbContext.Departments
            .FindAsync(command.DepartmentId, cancellationToken)
            ?? throw new DepartmentNotFoundException(command.DepartmentId);

        dbContext.Departments.Remove(department);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteDepartmentResult(true);
    }
}
